using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private LevelFade LevelTransitionFade;

    void Start()
    {
        KillCounter.Value = 0;
        currentLevel.Value = 2;
        LevelTransitionFade = GetComponentInChildren<LevelFade>();
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(titleScreen.Value);
        }

        switch (currentLevel.Value)
        {
            case 1:
                if(KillCounter.Value >= ClearCondition_1.Value)
                {
                    LevelTransitionFade.StartFade();
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                }
                break;
            case 2:
                if (KillCounter.Value >= ClearCondition_2.Value)
                {
                    LevelTransitionFade.StartFade();
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                }
                break;
            case 3:
                if (KillCounter.Value >= ClearCondition_3.Value)
                {
                    LevelTransitionFade.StartFade();
                    //Disable mob spawner for bossfight
                    //or skip to boss scene

                    currentLevel.Value += 1;
                }
                break;
            default:
                break;
        }
    }
}
