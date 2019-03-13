﻿using System.Collections;
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


    public void OnHit()
    {
       
        Flash();
        Knockback();
    }

    public void Flash()
    {
        if (anim.name == "EnemySprite 1" || anim.name == "EnemySprite 2" || anim.name == "PlayerSprite")
        {
            anim.SetBool("IsHit", true);
            Invoke("ResetColor", 0.05f);
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
        var rotation = new Quaternion(0, 0, 0, 0);
        Instantiate(Blood, new Vector3(transform.position.x, transform.position.y, 0), rotation);
    }

    void ResetColor()
    {
            anim.SetBool("IsHit", false);   
    }
}
