using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName = "Alien/AlienStats")]
public class AlienStatsObject : ScriptableObject
{
    [Header("Alien stats")]
    public float AlienSpeed;
    public int AlienLevel;
    public bool isKillable;
    [Header("Dash Ability")]
    public KeyCode DashKey = KeyCode.Q;
    public float StartDashCooldown;
    public float DashCooldown;
    public float DashDuration;
    public float DashDistance;
    public float DashSpeed;
    public bool DashOnCooldown;
    public float waitBeforeDash;

    [Header("Fireball Ability")]
    public KeyCode FireballKey = KeyCode.E;
    public bool FireballSpawned;
    public bool FireballOnCooldown;
    public float StartFireballCooldown;
    public float FireballCooldown;

    [Header("Alien sounds")] 
    public SimpleAudioEvent dashSound;
    public SimpleAudioEvent shootFireball;

    [Header("Fix alien dropping too low")] 
    public int returningLocation;
}
