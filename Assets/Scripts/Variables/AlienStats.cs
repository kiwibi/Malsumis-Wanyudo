using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName = "Alien/AlienStats")]
public class AlienStats : ScriptableObject
{
    [Header("Alien stats")]
    public float AlienSpeed;
    public int AlienLevel;
    [Header("Dash Ability")]
    public KeyCode DashKey = KeyCode.LeftControl;
    public float DashCooldown;
    public float DashDuration;
    public float DashDistance;
    public float DashSpeed;
    public bool DashOnCooldown;
    
    [Header("Fireball Ability")]
    public KeyCode FireballKey = KeyCode.LeftShift;
    public bool FireballSpawned;
    public bool FireballOnCooldown;
    public float FireballCooldown;
    public float FireballDuration;
}
