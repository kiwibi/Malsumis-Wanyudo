using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SelectMusicTrack : MonoBehaviour
{
    public IntVariable currentLevel;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    public AudioClip level4intro;
    public AudioClip level4;
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (currentLevel.Value == 1)
        {
            audioSource.clip = level1;
        } else if (currentLevel.Value == 2)
        {
            audioSource.clip = level2;
        } else if (currentLevel.Value == 3)
        {
            audioSource.clip = level3;
        } else
        {
            audioSource.clip = level4intro;
        }

        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel.Value > 3)
        {
            if (audioSource.clip == level4intro)
            {
                audioSource.loop = false;
                float trackProgress = audioSource.time / level4intro.length;

                if (trackProgress > 0.99f)
                {
                    audioSource.clip = level4;
                    audioSource.loop = true;
                    audioSource.Play();
                }  
            }
        }
    }
}
