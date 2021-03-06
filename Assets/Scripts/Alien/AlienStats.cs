﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienStats : Stats
{
    public GameObject blood;
    public AlienStatsObject statsObject;
    public IntReference AlienMaxHealth;
    public IntVariable AlienHealth;
    private int nextSpeedUp;
    public readonly int speedUpSteps = 15;

    public SimpleAudioEvent hurtSound;
    public SimpleAudioEvent dieSound;
    private Light lightSource;

    private StateController controller;

    public float FireballMaxCooldown;
    public float FireballMinCooldown;
    private float DashCooldown;
    private float AlienSpeed;
    private StateController stateController;
    private AudioSource audioSource;
    private bool playSound = true;

    private Animator anim;
    private bool isDead;
    private Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        // modify stats object
        statsObject.FireballOnCooldown = true;
        statsObject.DashOnCooldown = true;

        // Lights on
        lightSource = GetComponentInChildren<Light>();
        if (lightSource)
        {
            lightSource.intensity = 5;
        }
        
        col = GetComponent<Collider2D>();

        // Set local variables
        FireballMaxCooldown = statsObject.FireballMaxCooldown;
        FireballMinCooldown = statsObject.FireballMinCooldown;
        DashCooldown = statsObject.DashCooldown;
        AlienSpeed = statsObject.AlienSpeed;

        AlienHealth.Value = AlienMaxHealth;
        nextSpeedUp = AlienHealth.Value - speedUpSteps;

        audioSource = GetComponentInChildren<AudioSource>();
        anim = GetComponentInChildren<Animator>();
        stateController = GetComponent<StateController>();
        
         col.enabled = true;
    }

    public override void DealDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        
        AlienHealth.Value -= damage;
        
        if (AlienHealth.Value <= 0)
        {
            isDead = true;
            Die();
            dieSound.Play(audioSource);
            return;
        }

        if(playSound)
        {
            playSound = false;
            hurtSound.Play(audioSource);
            StartCoroutine(FinishSound());
        }

        anim.SetBool("IsHit", true);
        Invoke("ResetColor", 0.05f);
        
        if (AlienHealth.Value <= nextSpeedUp)
        {
            nextSpeedUp -= speedUpSteps;
            ChangeAttackSpeeds(0.1f);
            DimLights(1);
        }
    }

    public override void Die()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
        stateController.Disable();
        anim.SetBool("Die", true);
        col.enabled = false;
        //Destroy(gameObject);
    }

    private IEnumerator FinishSound()
    {
     yield return new WaitForSeconds(0.9f);
     playSound = true;
    }

    private void DimLights(int intensity)
    {
        lightSource.intensity -= intensity;
    }

    private void ChangeSpeed(float speed)
    {
        AlienSpeed += speed;
    }

    private void ChangeAttackSpeeds(float speed)
    {
        FireballMaxCooldown -= speed;
        FireballMinCooldown -= speed;
        DashCooldown -= speed;
    }
    
    void ResetColor()
    {
        anim.SetBool("IsHit", false);   
    }
}
