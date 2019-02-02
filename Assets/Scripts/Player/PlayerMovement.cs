using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public GameObject Bullet;

    private PlayerStats stats;
    private float playerPistolCooldown;
    private float timeBetweenShoots;

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
        if(stats.pistolCooldown.Value > 0)
        {
            playerPistolCooldown -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) == true && playerPistolCooldown < 0)
        {
            timeBetweenShoots = stats.pistolCooldown.Value;
           
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y,0), transform.rotation);
            playerPistolCooldown = stats.pistolCooldown.Value;
        }
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
       
        transform.position = new Vector3(

            Mathf.Clamp(transform.position.x , 0.1f , screenPos.x),
            Mathf.Clamp(transform.position.y, 0.1f , screenPos.y),
            0
            );

    }
}
