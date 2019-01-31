using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float m_speed;
    void FixedUpdate()
    {
       GetComponent<Rigidbody2D>().velocity = transform.up * m_speed;
    }

    void Update()
    {
        if(transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
