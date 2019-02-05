using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public FloatReference speed;
    public FloatReference pistolCooldown;
    public IntReference MaxHealth;
    public IntReference StartingHealth;

    private int m_Health;

    public int Health { get => m_Health; set => m_Health = value; }

    private void Start()
    {
        m_Health = MaxHealth.Value;
    }
}
