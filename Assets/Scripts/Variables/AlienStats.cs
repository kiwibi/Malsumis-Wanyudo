using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName = "Alien/AlienStats")]
public class AlienStats : ScriptableObject
{
    public float AlienSpeed;
    public int AlienLevel;
    public float DashCooldown;
    public float DashDuration;
    public int CurrentLevel;
    public KeyCode DashKey = KeyCode.LeftControl;
    public float DashDistance;
    public float DashSpeed;
}
