using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class SelectMusicTrack : MonoBehaviour
{
    public IntVariable currentLevel;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
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
            audioSource.clip = level4;
        }

        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
