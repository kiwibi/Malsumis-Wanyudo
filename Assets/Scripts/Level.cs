using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
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

    public GameObject levelCleared;

    [Header("Audio")] 
    public SimpleAudioEvent level1Transition;
    public SimpleAudioEvent level2Transition;
    public SimpleAudioEvent level3Transition;
    
    private AudioPlayer audioPlayer;

    void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        if (levelCleared == null)
        {
            Debug.LogError("Level clear not set");
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
                levelCleared.SetActive(true);
                StartCoroutine(TransitionScene("Transition1", 2));
            }
        }
        else if (currentLevel.Value == 2)
        {
            if (KillCounter.Value >= ClearCondition_2.Value)
            {
                levelCleared.SetActive(true);
                StartCoroutine(TransitionScene("Transition2", 3));
            }
        }
        else if (currentLevel.Value == 3)
        {
            if (KillCounter.Value >= ClearCondition_3.Value)
            {
                levelCleared.SetActive(true);
                StartCoroutine(TransitionScene("Transition3", 4));
            }
        }
    }

    private IEnumerator TransitionScene(string scene, int level)
    {
        pauseMenu.isPaused = true;
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(scene);
        pauseMenu.isPaused = false;
        playerHealth.Value = playerMaxHealth; // Should not be needed here
        currentLevel.Value = level;

    }
}
