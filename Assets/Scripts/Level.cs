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

    [Header("Audio")] 
    public SimpleAudioEvent level1Transition;
    public SimpleAudioEvent level2Transition;
    public SimpleAudioEvent level3Transition;
    
    private AudioPlayer audioPlayer;

    void Start()
    {
        KillCounter.Value = 0;
        currentLevel.Value = 1;
        audioPlayer = GetComponent<AudioPlayer>();
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
                    audioPlayer.PlaySound();
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                    playerHealth.Value = playerMaxHealth;
                }
                break;
            case 2:
                if (KillCounter.Value >= ClearCondition_2.Value)
                {
                    audioPlayer.PlaySound();  
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                    playerHealth.Value = playerMaxHealth;
                }
                break;
            case 3:
                if (KillCounter.Value >= ClearCondition_3.Value)
                {
                    audioPlayer.PlaySound(); 
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
