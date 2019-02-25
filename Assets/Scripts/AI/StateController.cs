using System.Collections;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("Health")]
    public IntReference AlienMaxHealth;
    public IntVariable AlienHealth;

    public AlienStats stats;

    [Header("State Machine")]
    public State currentState;
    public State remainState;
    public AlienStatsObject statsObject;

    [Header("Show state color in editor")]
    public Transform stateVisualizer;

    // TODO find a way to do this better
    [Header("Used for resetting abilities")]
    public State dashState;
    public State followState;
    public State fireballState;
    public State bossDashState;
    public State bossFollowState;
    public State bossFireballState;

    [Header("Spawn this Fireball prefab")]
    public GameObject fireball;

    [Header("Level info")]
    public IntVariable currentLevel;

    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Vector3 dashStartingPosition;

    private bool aiActive = true;
    private BoxCollider2D collider2d;
    private AudioPlayer audioPlayer;
    private Light lightSource;

    private void OnDrawGizmos()
    {
        if (currentState != null && stateVisualizer != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(stateVisualizer.position, 0.7f);
        }
    }

    private void Start()
    {
        stats = GetComponent<AlienStats>();
        collider2d = GetComponent<BoxCollider2D>();
        if (!statsObject.isKillable)
        {
            collider2d.enabled = false;
        }
        else
        {
            collider2d.enabled = true;
        }

        StartCoroutine("ResetDash");
        StartCoroutine("ResetFireBall");
        FindTarget();
        audioPlayer = GetComponent<AudioPlayer>();
        lightSource = GetComponentInChildren<Light>();

        AlienHealth.Value = AlienMaxHealth.Value;
    }

    private void Update()
    {
        if (!aiActive)
        {
            return;
        }

        statsObject.AlienLevel = currentLevel.Value;
        currentState.UpdateState(this);
    }

    private void FindTarget()
    {
        chaseTarget = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AlienTarget>().transform;
    }

    public void TransitionToState(State nextState)
    {
        if (currentState == followState && nextState == dashState || currentState == bossFollowState && nextState == bossDashState)
        {
            PlayDashSound();
        }

        if (currentState == followState && nextState == fireballState || currentState == bossFollowState && nextState == bossFireballState)
        {
            PlayFireballLaunchSound();
        }

        if (currentState == dashState && nextState == followState || currentState == bossDashState && nextState == bossFollowState)
        {
            StartCoroutine("ResetDash");
        }
        else if (currentState == fireballState && nextState == followState || currentState == bossFireballState && nextState == bossFollowState)
        {
            StartCoroutine("ResetFireBall");
        }

        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }

    public void PlayDashSound()
    {
        audioPlayer.AudioEvent = statsObject.dashSound;
        audioPlayer.PlaySound();
    }

    public void PlayFireballLaunchSound()
    {
        audioPlayer.AudioEvent = statsObject.shootFireball;
        audioPlayer.PlaySound();
    }

    public void SetLightColor(Color color)
    {
        lightSource.color = color;
    }

    private IEnumerator ResetDash()
    {
        if (!statsObject.isKillable)
        {
            collider2d.enabled = false;
        }
        statsObject.DashOnCooldown = true;
        yield return new WaitForSeconds(statsObject.DashCooldown);
        statsObject.DashOnCooldown = false;
    }

    private IEnumerator ResetFireBall()
    {
        statsObject.FireballOnCooldown = true;
        statsObject.FireballSpawned = false;
        statsObject.FireballCooldown = Random.Range(stats.FireballMinCooldown, stats.FireballMaxCooldown);
        yield return new WaitForSeconds(statsObject.FireballCooldown);
        statsObject.FireballOnCooldown = false;
    }
}
