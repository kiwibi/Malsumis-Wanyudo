using System.Collections;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [Header("Health")]
    public IntReference AlienMaxHealth;
    public IntVariable AlienHealth;

    [Header("State Machine")]
    public State currentState;
    public State remainState;
    public AlienStatsObject statsObject;

    [Header("Show state color in editor")]
    public Transform stateVisualizer;

    // TODO find a way to do this better
    [Header("Used for resetting abilities")]
    public State dashState;
    public State prepareDashState;
    public State returnDashState;
    public State followState;
    public State fireballState;
    public State bossDashState;
    public State bossFollowState;
    public State bossFireballState;
    public State fanOfFireState;

    [Header("Spawn this Fireball prefab")]
    public GameObject fireball;

    [Header("Materials for line renderer")]
    public Material FireballMaterial;
    public Material DashMaterial;

    [Header("Level info")]
    public IntVariable currentLevel;

    [HideInInspector] public AlienStats stats;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public Vector3 dashStartingPosition;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    private bool aiActive = true;
    private BoxCollider2D collider2d;
    private AudioPlayer audioPlayer;
    private Light lightSource;
    private Vector3 dashTarget;

    public Vector3 targetPos;
    public bool hasTarget;

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
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

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

    public void Disable()
    {
        aiActive = false;
    }

    private void FindTarget()
    {
        chaseTarget = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AlienTarget>().transform;
    }

    public void TransitionToState(State nextState)
    {
        if (currentState == prepareDashState && nextState == dashState || currentState == bossFollowState && nextState == bossDashState)
        {
            PlayDashSound();
        }

        if (currentState == followState && nextState == fireballState || currentState == bossFollowState && nextState == bossFireballState)
        {
            PlayFireballLaunchSound();
        }

        if (currentState == returnDashState && nextState == followState || currentState == bossDashState && nextState == bossFollowState)
        {
            StartCoroutine("ResetDash");
        }
        else if (currentState == fireballState && nextState == followState || currentState == bossFireballState && nextState == bossFollowState)
        {
            StartCoroutine("ResetFireBall");
        }
        else
        {
            if (currentState == fanOfFireState && nextState == bossFollowState)
            {
                StartCoroutine("ResetFanOfFire)");
            }
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

    public void SetDashTarget(Vector3 target)
    {
        dashTarget = target;
        dashStartingPosition = transform.position;
        dashStartingPosition.z = 0;
    }

    public Vector3 GetDashPosition()
    {
        return dashTarget;
    }

    public void SpawnFireBall()
    {
        for (int fireballNumber = 0; fireballNumber < statsObject.FanOfFireFireBalls; fireballNumber++)
        {
            var ball = Instantiate(fireball, transform.position, Quaternion.identity);
            fireball.transform.rotation = Quaternion.AngleAxis(statsObject.FanOfFireStartAngle + (statsObject.FanOfFireAngle * fireballNumber), Vector3.back);
        }
        statsObject.FanOfFireDone = true;
        //StartCoroutine(SpawnFireBalls());
    }

    private IEnumerator SpawnFireBalls()
    {
        for (int fireballNumber = 0; fireballNumber < statsObject.FanOfFireFireBalls; fireballNumber++)
        {
            var ball = Instantiate(fireball, transform.position, Quaternion.identity);
            fireball.transform.rotation = Quaternion.AngleAxis(statsObject.FanOfFireStartAngle + (statsObject.FanOfFireAngle * fireballNumber), Vector3.back);
            yield return new WaitForSeconds(1f);
        }
        
        for (int fireballNumber = statsObject.FanOfFireFireBalls; fireballNumber > 0; fireballNumber++)
        {
            var ball = Instantiate(fireball, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
            fireball.transform.rotation = Quaternion.AngleAxis(statsObject.FanOfFireStartAngle + (statsObject.FanOfFireAngle * fireballNumber), Vector3.back);
        }
        
        statsObject.FanOfFireDone = true;
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

    private IEnumerator ResetFanOfFire()
    {
        statsObject.FanOfFireDone = false;
        statsObject.FanOfFireOnCooldown = true;
        yield return new WaitForSeconds(statsObject.FanOfFireCooldown);
        statsObject.FanOfFireOnCooldown = false;
    }
}
