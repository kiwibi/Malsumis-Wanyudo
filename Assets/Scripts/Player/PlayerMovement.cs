using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class PlayerMovement : MonoBehaviour
{
    public FloatVariable speed;
    public FloatVariable pistolCooldown;
    public GameObject Bullet;
    public Boundary boundary;
    private float playerPistolCooldown;
    private float timeBetweenShoots;
    
    void FixedUpdate()
    {
        //Get input
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        //using the input to create a new vector to move the playerobject with
        Vector2 movement = new Vector2(HorizontalMove, VerticalMove);
        transform.Translate(movement * Time.deltaTime * speed.Value);
        if(pistolCooldown.Value > 0)
        {
            playerPistolCooldown -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) == true && playerPistolCooldown < 0)
        {
            timeBetweenShoots = pistolCooldown.Value;
           
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y,0), transform.rotation);
            playerPistolCooldown = pistolCooldown.Value;
        }
        //Will keep the player inside the Boundary if wanted
        //GetComponent<Rigidbody2D>().position = new Vector2
        //(
        //    Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
        //    Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
        //);
    }
}
