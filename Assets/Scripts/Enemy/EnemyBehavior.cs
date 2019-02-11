﻿using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject Bullet;

    private EnemyStats stats;
    public int strafeDirection;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        var randomDirection = Random.Range(1, 3);
        if(randomDirection == 1)
        {
            strafeDirection = 1;
        } else
        {
            strafeDirection = -1;
        }
    }

    void Update()
    {
        Move();
    }

    public void Shoot()
    {
        var bullet = Instantiate(Bullet, new Vector3(transform.GetChild(1).position.x, transform.GetChild(1).position.y, 0), transform.rotation);
    }

    public void Move()
    {
        Vector3 direction = new Vector3(strafeDirection * stats.StrafeSpeed.Value, -1 * stats.Speed.Value, 0);
        gameObject.transform.Translate(direction * Time.deltaTime);
    }

    public void ChangeDirection()
    {
        strafeDirection *= -1;
    }
}
