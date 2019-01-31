using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public FloatVariable Speed;
    public bool BulletDirectionUp = true;
    // Bullet direction up by default
    private Vector3 bulletDirection = new Vector3(0, 1, 0);
    void FixedUpdate()
    {
        if (!BulletDirectionUp)
        {
            bulletDirection.y = -1;
        }
       //GetComponent<Rigidbody2D>().velocity = bulletDirection  * Speed.Value;
       transform.Translate(bulletDirection * Time.deltaTime * Speed.Value);
    }

    void Update()
    {
        /*
        if(transform.position.y > 5)
        {
            Destroy(gameObject);
        }
        */
    }
}
