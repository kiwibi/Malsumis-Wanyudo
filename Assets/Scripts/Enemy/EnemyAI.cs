using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(EnemyBehavior))]
public class EnemyAI : MonoBehaviour
{
    private EnemyStats stats;
    private EnemyBehavior behavior;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        behavior = GetComponent<EnemyBehavior>();
        // Shoot continuously every shootingdelay (seconds)
        InvokeRepeating("Shoot", stats.ShootingDelay.Value, stats.ShootingDelay.Value);
    }

    void Update()
    {
        
        if(stats.HP.Value <= 0)
        {
            Die();
        }
    }

    void Shoot()
    {
        behavior.Shoot();   
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
