using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SoundEvents : MonoBehaviour
{
    public SimpleAudioEvent fireballSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnEnable()
    {
        EventManager.StartListening("Fireball", FireBallSound);
    }

    void OnDisable()
    {
        EventManager.StopListening("Fireball", FireBallSound);
    }

    void FireBallSound()
    {
        fireballSound.Play(audioSource);
    }
}