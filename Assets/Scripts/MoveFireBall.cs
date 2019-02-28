using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;

public class MoveFireBall : MonoBehaviour
{
    public FloatReference FireballSpeed;
    public bool FollowPlayer = false;
    private Vector3 targetLocation = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private SpriteRenderer fireballSprite;

    void Start()
    {
        fireballSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(!FollowPlayer)
        {
            if (targetLocation == Vector3.zero)
            {
                Rotate();
                targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetLocation.z = 0;
                direction = (targetLocation - transform.position).normalized;
            }
            transform.Translate(direction * FireballSpeed * Time.deltaTime);
        } else
        {
            if(targetLocation == Vector3.zero)
            {
                Rotate();
                targetLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
                direction = (targetLocation - transform.position).normalized;
            }

            transform.Translate(direction * FireballSpeed * Time.deltaTime);
        }

    }

    private void Rotate()
    {
        if (!FollowPlayer)
        {
            Vector3 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 up = new Vector3(0, 0, 1);
            var rotation = Quaternion.LookRotation(dir, up);
            rotation.x = 0;
            rotation.y = 0;
            fireballSprite.transform.rotation = rotation;
        }else
        {
            Vector3 dir = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position; ;
            Vector3 up = new Vector3(0, 0, 1);
            var rotation = Quaternion.LookRotation(dir, up);
            rotation.x = 0;
            rotation.y = 0;
            fireballSprite.transform.rotation = rotation;
        }
    }
}
