using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public FloatReference speed;
    public FloatReference pistolCooldown;
    public IntReference MaxHealth;
    public IntReference StartingHealth;
    public IntVariable CurrentHealth;

    void Start()
    {
        CurrentHealth.Value = MaxHealth.Value;
        
    }

    void Update()
    {
        if (CurrentHealth.Value <= 0)
        {
            Die();
        }
    }

    public void DealDamage(int value)
    {
        Debug.Log("should deal dmg");
        CurrentHealth.Value -= value;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
