using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public BoolVariable SpawnerOn;
    public StringVariable titleScreen;
    public IntVariable currentLevel;
    public IntVariable KillCounter;
    //Clear first lvl
    public IntReference ClearCondition_1;
    //Clear second lvl
    public IntReference ClearCondition_2;
    //Clear third and entern boss lvl
    public IntReference ClearCondition_3;

    public IntVariable playerHealth;
    public IntReference playerMaxHealth;

    public StringVariable loseScreen;

    public float transitionDelay;

    [Header("Audio")] 
    public SimpleAudioEvent level1Transition;
    public SimpleAudioEvent level2Transition;
    public SimpleAudioEvent level3Transition;
    
    private AudioPlayer audioPlayer;

    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        if(currentLevel.Value == 1)
        {
            KillCounter.Value = 0;
        }
        else if(currentLevel.Value == 2)
        {
            KillCounter.Value = 50;
        }
        else if (currentLevel.Value == 3)
        {
            KillCounter.Value = 100;
        }
    }
    void Update()
    {
        if (playerHealth.Value <= 0)
        {
            SceneManager.LoadScene(loseScreen.Value);
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            currentLevel.Value = 3;
        }

        if (currentLevel.Value == 1)
        {
            if (KillCounter.Value >= ClearCondition_1.Value)
            {
                SpawnerOn.Value = false;
                StartCoroutine(TransitionScene(transitionDelay, "Transition1", 2));
            }
        }
        else if (currentLevel.Value == 2)
        {
            if (KillCounter.Value >= ClearCondition_2.Value)
            {
                SpawnerOn.Value = false;
                StartCoroutine(TransitionScene(transitionDelay,"Transition2", 3));
            }
        }
        else if (currentLevel.Value == 3)
        {
            if (KillCounter.Value >= ClearCondition_3.Value)
            {
                SpawnerOn.Value = false;
                StartCoroutine(TransitionScene(transitionDelay,"Transition3", 4));
            }
        }
    }

    private IEnumerator TransitionScene(float delay, string scene, int level)
    {
        // Wait for player to kill rest of the enemies
        yield return new WaitForSeconds(delay);
        //levelCleared.SetActive(true);
        //pauseMenu.isPaused = true;
        SceneManager.LoadScene(scene);
        pauseMenu.isPaused = false;
        playerHealth.Value = playerMaxHealth; // Should not be needed here
        currentLevel.Value = level;

    }
}
