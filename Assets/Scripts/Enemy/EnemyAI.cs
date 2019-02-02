using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(EnemyBehavior))]
public class EnemyAI : MonoBehaviour
{
    private EnemyStats stats;
    private EnemyBehavior behavior;

    private IEnumerator coroutine;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        behavior = GetComponent<EnemyBehavior>();
        coroutine = ShootDecision();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        if(stats.HP <= 0)
        {
            behavior.Die();
            StopAllCoroutines();
        }
    }

    void Shoot()
    {
        behavior.Shoot();   
    }

    IEnumerator ShootDecision()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(stats.MinShootDelay.Value, stats.MaxShootDelay.Value));
            Shoot();
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
