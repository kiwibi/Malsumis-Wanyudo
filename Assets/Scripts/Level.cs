using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public IntVariable currentLevel;
    public IntVariable KillCounter;
    //Clear first lvl
    public IntReference ClearCondition_1;
    //Clear second lvl
    public IntReference ClearCondition_2;
    //Clear third and entern boss lvl
    public IntReference ClearCondition_3;

    void Start()
    {
        KillCounter.Value = 0;
        currentLevel.Value = 1;
    }
    void Update()
    {
        switch(currentLevel.Value)
        {
            case 1:
                if(KillCounter.Value >= ClearCondition_1.Value)
                {
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                }
                break;
            case 2:
                if (KillCounter.Value >= ClearCondition_2.Value)
                {
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                }
                break;
            case 3:
                if (KillCounter.Value >= ClearCondition_3.Value)
                {
                    //Disable mob spawner for bossfight
                    currentLevel.Value += 1;
                }
                break;
            default:
                break;
        }
    }

}
