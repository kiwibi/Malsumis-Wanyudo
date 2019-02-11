using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource AudioSource;
    // Start is called before the first frame update

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound)
    {
        AudioSource.clip = sound;
        AudioSource.Play();
    }
    
    #region Singleton

    private static SoundPlayer instance;
    public static SoundPlayer GetInstance() {
        return instance;
    }

    void Awake() {
        instance = this;
    }
    #endregion
}
