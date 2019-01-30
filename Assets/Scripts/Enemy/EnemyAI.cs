using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(EnemyBehavior))]
public class EnemyAI : MonoBehaviour
{
    private EnemyStats stats;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        if((int)stats.HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
