using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public FloatVariable Speed;
    public bool BulletDirectionUp = true;
    private Vector3 targetLocation = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    private Light lights;
    
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.8f);
        lights = GetComponent<Light>();

        StartCoroutine("Flash");
    }
    
    void Update()
    {
        if (BulletDirectionUp && targetLocation == Vector3.zero) //Player
        {
            targetLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetLocation.z = 0;
            direction = (targetLocation - transform.position).normalized;
        }
        else if (!BulletDirectionUp && targetLocation == Vector3.zero)//Enemy
        {
            targetLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
            direction = (targetLocation - transform.position).normalized;

        }
        transform.Translate(direction * Speed.Value * Time.deltaTime);
    }

    private IEnumerator Flash()
    {
        lights.enabled = true;
        yield return new WaitForSeconds(0.05f);
        lights.enabled = false;
    }
}
