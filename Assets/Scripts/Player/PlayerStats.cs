using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public FloatReference speed;
    public FloatReference pistolCooldown;
    public IntReference MaxHealth;
    public IntReference StartingHealth;
    public IntVariable m_Health;

  

    private void fixedUpdate()
    {
        if(m_Health.Value <= 0)
        {
            Die();
        }
    }

    public void DealDamage(int value)
    {
        m_Health.Value -= value;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
