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
    private FlashOnHit hitFlash;

    void Start()
    {
        m_Health = MaxHP;
        hitFlash = GetComponentInChildren<FlashOnHit>();
    }

    void Update()
    {
        if(m_Health <= 0)
        {
            hitFlash.BloodSpawn();
            Die();
        }
    }

    public override void DealDamage(int value) {
        hitFlash.Flash();
        m_Health -= value;
    }

    public override void Die()
    {
        Debug.Log("Enemy health: " + KillCount.Value);
        KillCount.Value++;
        Destroy(gameObject);
    }
}
