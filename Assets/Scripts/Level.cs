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
    public IntReference fadeOutTime;
    //Clear first lvl
    public IntReference ClearCondition_1;
    //Clear second lvl
    public IntReference ClearCondition_2;
    //Clear third and entern boss lvl
    public IntReference ClearCondition_3;

    public IntVariable playerHealth;
    public IntReference playerMaxHealth;

    public StringVariable loseScreen;

    private Text transitionText;
    
    [Header("Audio")] 
    public SimpleAudioEvent level1Transition;
    public SimpleAudioEvent level2Transition;
    public SimpleAudioEvent level3Transition;
    

    private LevelFade LevelTransitionFade;
    private AudioPlayer audioPlayer;
    private pauseMenu PauseMenu;

    void Start()
    {
        transitionText = GetComponentInChildren<Text>();
        transitionText.text = "They want to take me away from you." 
            + '\n' + "You have to kill them."
            + '\n' + "Please, there is no other way";
        KillCounter.Value = 0;
        currentLevel.Value = 1;
        LevelTransitionFade = GetComponentInChildren<LevelFade>();
        audioPlayer = GetComponent<AudioPlayer>();
        PauseMenu = GetComponentInChildren<pauseMenu>();
        Time.timeScale = 0;
        LevelTransitionFade.StartScene();
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
        switch (currentLevel.Value)
        {
            case 1:
                if(KillCounter.Value >= ClearCondition_1.Value)
                {
                    transitionText.text = "Please, do not let them take me away!";
                    audioPlayer.PlaySound();
                    LevelTransitionFade.StartFade();
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                    playerHealth.Value = playerMaxHealth;
                }
                break;
            case 2:
                if (KillCounter.Value >= ClearCondition_2.Value)
                {
                    transitionText.text = "Their blood is on your hands. But I do not hold that against you";
                    audioPlayer.PlaySound(); 
                    LevelTransitionFade.StartFade();  
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                    playerHealth.Value = playerMaxHealth;
                }
                break;
            case 3:
                if (KillCounter.Value >= ClearCondition_3.Value)
                {
                    transitionText.text = "Thank you, John" 
                                        + '\n' + "You showed your species' true nature."
                                        + '\n' + "Now you are no longer of any use to me";
                    audioPlayer.PlaySound(); 
                    LevelTransitionFade.StartFade();
                    KillCounter.Value = 0;
                    playerHealth.Value = playerMaxHealth;
                    currentLevel.Value += 1;
                    SceneManager.LoadScene("BossLevel");
                }
                break;
            default:
                break;
        }
    }
}
