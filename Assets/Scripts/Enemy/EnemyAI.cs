using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyStats))]
[RequireComponent(typeof(EnemyBehavior))]
public class EnemyAI : MonoBehaviour
{
    private EnemyStats stats;
    private EnemyBehavior behavior;

    private void Start()
    {
        stats = GetComponent<EnemyStats>();
        behavior = GetComponent<EnemyBehavior>();
        StartCoroutine(ShootDecision());
        StartCoroutine(ChangeDirectionDecision());
    }

    private IEnumerator ShootDecision()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(stats.MinShootDelay.Value, stats.MaxShootDelay.Value));
            behavior.Shoot();
        }
    }

    private IEnumerator ChangeDirectionDecision()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(stats.MinChangeDirectionDelay.Value, stats.MaxChangeDirectionDelay.Value));
            behavior.ChangeDirection();
        }
    }
}
