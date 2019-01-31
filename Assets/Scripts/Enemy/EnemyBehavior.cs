using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Bullet;
    
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

    public void Shoot()
    {
        Instantiate(Bullet, transform);
    }

    public void Move()
    {
        gameObject.transform.Translate(Vector3.down * stats.Speed.Value * Time.deltaTime);
    }
}
