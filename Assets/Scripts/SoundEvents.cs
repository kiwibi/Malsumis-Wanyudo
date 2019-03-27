﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SoundEvents : MonoBehaviour
{
    public SimpleAudioEvent fireballSound;
    public SimpleAudioEvent menuclickSound;
    private AudioSource audioSource;

    public static SoundEvents instance = null;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnEnable()
    {
        EventManager.StartListening("Fireball", FireBallSound);
        EventManager.StartListening("MenuClick", menuClickSound);
    }

    void OnDisable()
    {
        EventManager.StopListening("Fireball", FireBallSound);
        EventManager.StopListening("MenuClick", menuClickSound);
    }

    void FireBallSound()
    {
        fireballSound.Play(audioSource);
    }

    void menuClickSound()
    {
        menuclickSound.Play(audioSource);
    }
}