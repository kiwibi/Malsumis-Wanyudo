using System.Collections;
using UnityEngine;

public class StateController : MonoBehaviour
{

    [Header("State Machine")]
    public State currentState;
    public State remainState;
    public AlienStatsObject stats;

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
        collider2d = GetComponent<BoxCollider2D>();
        if (!stats.isKillable)
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
    }

    private void Update()
    {
        if (!aiActive)
        {
            return;
        }

        stats.AlienLevel = currentLevel.Value;
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
        audioPlayer.AudioEvent = stats.dashSound;
        audioPlayer.PlaySound();
    }

    public void PlayFireballLaunchSound()
    {
        audioPlayer.AudioEvent = stats.shootFireball;
        audioPlayer.PlaySound();
    }

    public void SetLightColor(Color color)
    {
        lightSource.color = color;
    }

    private IEnumerator ResetDash()
    {
        if (!stats.isKillable)
        {
            collider2d.enabled = false;
        }
        stats.DashOnCooldown = true;
        yield return new WaitForSeconds(stats.DashCooldown);
        stats.DashOnCooldown = false;
    }

    private IEnumerator ResetFireBall()
    {
        stats.FireballOnCooldown = true;
        stats.FireballSpawned = false;
        stats.FireballCooldown = Random.Range(stats.FireballMinCooldown, stats.FireballMaxCooldown);
        yield return new WaitForSeconds(stats.FireballCooldown);
        stats.FireballOnCooldown = false;
    }
}
