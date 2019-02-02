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
        StartCoroutine(ShootDecision());
        StartCoroutine(ChangeDirectionDecision());
    }

    void Update()
    {
        if(stats.HP <= 0)
        {
            behavior.Die();
            StopAllCoroutines();
        }
    }

    IEnumerator ShootDecision()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(stats.MinShootDelay.Value, stats.MaxShootDelay.Value));
            behavior.Shoot();
        }
    }

    IEnumerator ChangeDirectionDecision()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(stats.MinShootDelay.Value, stats.MaxShootDelay.Value));
            behavior.ChangeDirection();
        }
    }
}
