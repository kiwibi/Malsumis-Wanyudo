using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemyStats stats;
    void Start()
    {
        stats = GetComponent<EnemyStats>();
        stats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        Move();

    }

    void Move()
    {
        gameObject.transform.Translate(Vector3.up * (float)stats.Speed * Time.deltaTime);
    }
}
