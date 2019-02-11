using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    public IntReference MaxHP;
    public FloatReference speed;
    public FloatReference pistolCooldown;
    public IntVariable CurrentHealth;
    public AudioClip shootGun;

    void Start()
    {
        CurrentHealth.Value = MaxHP.Value;
        
    }

    void Update()
    {
        //Debug.Log("Player health: " + CurrentHealth.Value);
        if (CurrentHealth.Value <= 0)
        {
            Die();
        }
    }

    public override void DealDamage(int value)
    {
        CurrentHealth.Value -= value;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
