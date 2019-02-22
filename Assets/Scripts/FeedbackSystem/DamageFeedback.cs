using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFeedback : MonoBehaviour
{
  
    public GameObject Blood;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void OnHit(bool Shake)
    {
       
        Flash();
        Knockback();
    }

    public void Flash()
    {
        if (anim.name == "EnemySprite 1" || anim.name == "EnemySprite 2")
        {
            anim.SetBool("IsHit", true);
            Invoke("ResetColor", 0.1f);
        }
    }

    public void Knockback()
    {
        GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 2);
        Invoke("ResetVelocity", 0.1f);
    }

    private void ResetVelocity()
    {
        GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, -.5f);
    }

    public void BloodSpawn()
    {
        var blood_pool = Instantiate(Blood, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation, GameObject.Find("GameArea/background/blood").transform);
        //Destroy(blood_pool, 5);
    }

    void ResetColor()
    {
            anim.SetBool("IsHit", false);   
    }
}
