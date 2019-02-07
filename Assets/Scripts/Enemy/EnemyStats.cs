using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    public IntVariable KillCount;
    public FloatReference MinShootDelay;
    public FloatReference MaxShootDelay;
    public FloatReference Speed;
    public FloatReference StrafeSpeed;
    public FloatReference MinChangeDirectionDelay;
    public FloatReference MaxChangeDirectionDelay;
    public IntReference MaxHP;
    private int m_Health;

    void Start()
    {
        m_Health = MaxHP;
    }

    void Update()
    {
        if(m_Health <= 0)
        {
            Die();
        }
    }

    public override void DealDamage(int value) {
        m_Health -= value;
    }

    public override void Die()
    {
        Debug.Log("Enemy health: " + KillCount.Value);
        KillCount.Value++;
        Destroy(gameObject);
    }
}
