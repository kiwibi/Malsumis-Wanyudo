using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class SelectMusicTrack : MonoBehaviour
{
    public static SelectMusicTrack instance = null;

    private bool played;

    public IntVariable currentLevel;
    public AudioClip menu;
    public AudioClip transition;
    public AudioClip winScreen;
    public AudioClip loseScreen;
    public AudioClip level1;
    public AudioClip level2;
    public AudioClip level3;
    public AudioClip level4intro;
    public AudioClip level4;
    private AudioSource audioSource;

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
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        var currentTrack = instance.audioSource.clip;
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "BossLevel")
            selectLevelMusic();
        else
            selectMenuMusic();

        //only play clip if its a new one
        if (currentTrack != instance.audioSource.clip)
        {
            instance.audioSource.Play();
        }
    }

    void selectMenuMusic()
    {
        instance.played = false;
        //check for winScene
        if (SceneManager.GetActiveScene().name == "WinScene")
        {
            instance.audioSource.clip = winScreen;
            return;
        }
        //check for loseScreen
        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "BossGameOver")
        {
            instance.audioSource.clip = loseScreen;
            return;
        }
        //check for transitionscenes
        for (int i = 1; i < 4; i++)
        {
            var name = "Transition" + i;
            if(SceneManager.GetActiveScene().name == name)
            {
                instance.audioSource.clip = transition;
                return;
            }
        }
        //if none of the above are true load menu music
        instance.audioSource.clip = menu;
    }

    void selectLevelMusic()
    {
        //Level 1 > 3
        if (currentLevel.Value == 1)
        {
            instance.audioSource.clip = level1;
        }
        else if (currentLevel.Value == 2)
        {
            instance.audioSource.clip = level2;
        }
        else if (currentLevel.Value == 3)
        {
            instance.audioSource.clip = level3;
        }
        //boss music
        if (currentLevel.Value > 3)
        {
            if(instance.played == false)
            {
                instance.audioSource.clip = level4intro;
                instance.played = true;
            }
            if (audioSource.clip == level4intro)
            {
                instance.audioSource.loop = false;
                float trackProgress = instance.audioSource.time / level4intro.length;

                if (trackProgress > 0.99f)
                {
                    instance.audioSource.clip = level4;
                    instance.audioSource.loop = true;
                    instance.audioSource.Play();
                }
            }
        }
    }   
}
