using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public FloatVariable Speed;
    public Vector3 direction;
    private Light lights;
    
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.8f);
        lights = GetComponent<Light>();

        StartCoroutine("Flash");
    }
    
    void Update()
    {
        transform.Translate(direction * Speed.Value * Time.deltaTime);
    }

    private IEnumerator Flash()
    {
        lights.enabled = true;
        yield return new WaitForSeconds(0.05f);
        lights.enabled = false;
    }
}
