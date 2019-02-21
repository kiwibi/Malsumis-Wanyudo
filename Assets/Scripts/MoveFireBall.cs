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
    void Update()
    {
        if(!FollowPlayer)
        {
            if (targetLocation == Vector3.zero)
            {
                targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetLocation.z = 0;
                direction = (targetLocation - transform.position).normalized;
            }
            transform.Translate(direction * FireballSpeed * Time.deltaTime);
        } else
        {
            if(targetLocation == Vector3.zero)
            {
                targetLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
                direction = (targetLocation - transform.position).normalized;
            }

            transform.Translate(direction * FireballSpeed * Time.deltaTime);
        }

    }
}
