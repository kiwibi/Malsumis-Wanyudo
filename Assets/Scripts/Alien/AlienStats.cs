using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : Stats
{
    public AlienStatsObject stats;

    // Start is called before the first frame update
    void Start()
    {
        stats.AlienHealth = stats.AlienMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DealDamage(int damage)
    {
        stats.AlienHealth -= damage;
        if(stats.AlienHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
