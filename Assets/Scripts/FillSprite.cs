using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSprite : MonoBehaviour
{
    private Image fillArea;

    private float checkPoint1;
    private float checkPoint2;
    private float multiplier;
    //private float checkPoint3;

    public IntVariable Currentlevel;
    public IntVariable CurrentKillCount;
    public IntVariable Level1Clear;
    public IntVariable Level2Clear;
    public IntVariable Level3Clear;

    void Start()
    {
        fillArea = GetComponent<Image>();
        checkPoint1 = 0.29f;
        checkPoint2 = 0.57f;
        switch(Currentlevel.Value)
        {
            case 1:
                multiplier = checkPoint1 / Level1Clear.Value;
                break;
            case 2:
                multiplier = checkPoint2 / Level2Clear.Value;
                break;
            case 3:
                multiplier = 1.0f / Level3Clear.Value;
                break;
        }

    }

    void Update()
    {
        switch (Currentlevel.Value)
        {
            case 1:

                fillArea.fillAmount = CurrentKillCount.Value * multiplier;
                break;
            case 2:
                fillArea.fillAmount = checkPoint1 + ((CurrentKillCount.Value - Level1Clear.Value) * multiplier);
                break;
            case 3:
                fillArea.fillAmount = checkPoint2 + ((CurrentKillCount.Value - Level2Clear.Value) * multiplier);
                break;
        }
    }
}
