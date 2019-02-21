using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private PlayerStats stats;
    public Animator animator;

    private SpriteRenderer playerSprite;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        //Get input
        float HorizontalMove = Input.GetAxisRaw("Horizontal");
        float VerticalMove = Input.GetAxisRaw("Vertical");
        //Movement Animation
        
        if(HorizontalMove > 0.5)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if(HorizontalMove < -0.5)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
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
        if(pauseMenu.isPaused == false)
            Rotate();
    }


    private void Rotate()
    {
        
        Vector3 dir =transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 up = new Vector3(0, 0, 1);
        var rotation = Quaternion.LookRotation(dir, up);
        rotation.x = 0;
        rotation.y = 0;
        playerSprite.transform.rotation = rotation;
    }
}
