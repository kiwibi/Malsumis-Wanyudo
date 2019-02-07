using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public IntVariable KillCount;
    public IntReference MaxHP;
    public FloatReference MinShootDelay;
    public FloatReference MaxShootDelay;
    public FloatReference Speed;
    public FloatReference StrafeSpeed;
    public FloatReference MinChangeDirectionDelay;
    public FloatReference MaxChangeDirectionDelay;
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

    public void DealDamage(int value)
    {
        m_Health -= value;
    }

    private void Die()
    {
        //Debug.Log(KillCount.Value);
        KillCount.Value++;
        Destroy(gameObject);
    }
}
