using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : Stats
{
    public IntVariable AlienMaxHealth;
    public IntVariable AlienHealth;

    // Start is called before the first frame update
    void Start()
    {
        AlienHealth.Value = AlienMaxHealth.Value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DealDamage(int damage)
    {
        AlienHealth.Value -= damage;
        if(AlienHealth.Value <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
