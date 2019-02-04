using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public GameObject Target;

    private AlienStats stats;

    void Start()
    {
        stats = GetComponent<AlienStats>();
    }
    
    void Update()
    {
        Vector2 movement = new Vector2(Target.transform.position.x, Target.transform.position.y);
        transform.Translate(movement * stats.AlienSpeed.Value * Time.deltaTime);

        if (Camera.main == null) return;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));

        transform.position = new Vector3(

            Mathf.Clamp(transform.position.x, 0.1f, screenPos.x),
            Mathf.Clamp(transform.position.y, 0.1f, screenPos.y),
            0
        );
    }
}
