using UnityEngine;

[CreateAssetMenu(menuName = "Alien/AlienStats")]
public class AlienStatsObject : ScriptableObject
{
    [Header("1-3 Levels: Alien Stats")]
    public float AlienSpeed;
    public int AlienLevel;
    public bool isKillable;

    [Header("1-3 Levels: Dash Ability")]
    public KeyCode DashKey = KeyCode.Q;
    public float StartDashCooldown;
    public float DashCooldown;
    public float DashDuration;
    public float DashDistance;
    public float DashSpeed;
    public bool DashOnCooldown;

    [Header("1-3 Levels: Fireball Ability")]
    public KeyCode FireballKey = KeyCode.E;
    public bool FireballSpawned;
    public bool FireballOnCooldown;
    public float FireballCooldown;

    [Header("BOSS: Fireball Ability")]
    public float FireballMaxCooldown;
    public float FireballMinCooldown;
    public int fireBalls;
    public int fireballAngle;
    public int fireballSpread;
    public int fireballAngle2;

    [Header("BOSS: Dash Ability")]
    public float waitBeforeDash;
    public Color dashColor;

    [Header("BOSS: Fan Of Fire")] 
    public bool FanOfFireOnCooldown;
    public float FanOfFireCooldown;
    public bool FanOfFireDone;
    public int FanOfFireAngle;
    public int FanOfFireStartAngle;
    public int FanOfFireFireBalls;
    
    [Header("BOSS: Fix boss dropping too low")]
    public int returningLocation;

    [Header("Alien sounds")]
    public SimpleAudioEvent dashSound;
    public SimpleAudioEvent shootFireball;
}
