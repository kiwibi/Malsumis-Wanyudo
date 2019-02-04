using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private PlayerStats stats;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        //Get input
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        //using the input to create a new vector to move the playerobject with
        Vector2 movement = new Vector2(HorizontalMove, VerticalMove);
        transform.Translate(movement * Time.deltaTime * stats.speed.Variable.Value);

        if (Camera.main == null) return;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
       
        transform.position = new Vector3(

            Mathf.Clamp(transform.position.x , 0.1f , screenPos.x),
            Mathf.Clamp(transform.position.y, 0.1f , screenPos.y),
            0
        );
    }
}
