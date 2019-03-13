using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    public IntVariable KillCounter;
    public IntVariable currentLevel;
    public FloatVariable heartColor;

    // Start is called before the first frame update
    void Start()
    {
                KillCounter.Value = 0;
                currentLevel.Value = 1;
                heartColor.Value = 0.0f;
    }
}
