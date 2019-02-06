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
        Debug.Log(CurrentHealth.Value);
        if (CurrentHealth.Value <= 0)
        {
            Die();
        }
    }

    public void DealDamage(int value)
    {
        CurrentHealth.Value -= value;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
