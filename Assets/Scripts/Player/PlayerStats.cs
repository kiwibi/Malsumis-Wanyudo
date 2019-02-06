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
            Destroy(gameObject);
        }
    }

    public void DealDamage(int value)
    {
        m_Health.Value -= value;
    }
}
