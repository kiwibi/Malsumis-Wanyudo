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
    public float speed;
    private float timeBetweenShoots;
    [SerializeField]
    private float pistolCooldown;
    public GameObject Bullet;
    public Boundary boundary;

    void FixedUpdate()
    {
        //Get input
        float HorizontalMove = Input.GetAxis("Horizontal");
        float VerticalMove = Input.GetAxis("Vertical");

        //using the input to create a new vector to move the playerobject with
        Vector2 movement = new Vector2(HorizontalMove, VerticalMove);
        GetComponent<Rigidbody2D>().velocity = movement * speed;
        if(timeBetweenShoots >= 0)
        {
            timeBetweenShoots--;
        }
        if (Input.GetKey(KeyCode.Space) == true && timeBetweenShoots < 0)
        {
            timeBetweenShoots = pistolCooldown;
            Instantiate(Bullet, transform);
        }
        //Will keep the player inside the Boundary if wanted
        GetComponent<Rigidbody2D>().position = new Vector2
        (
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax)
        );
    }
}
