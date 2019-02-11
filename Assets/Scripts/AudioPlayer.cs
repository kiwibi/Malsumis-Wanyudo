using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public SimpleAudioEvent AudioEvent;
    private AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        AudioEvent.Play(AudioSource);
    }
}
