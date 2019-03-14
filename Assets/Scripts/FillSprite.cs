using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSprite : MonoBehaviour
{
    private Image fillArea;

    private float checkPoint1;
    private float checkPoint2;
    //private float checkPoint3;

    public IntVariable Currentlevel;
    public IntVariable CurrentKillCount;
    public FloatVariable fillAmount;

    void Start()
    {
        fillArea = GetComponent<Image>();
        checkPoint1 = 0.29f;
        checkPoint2 = 0.57f;

    }

    void Update()
    {
        fillAmount.Value = fillProgress();
        fillArea.fillAmount = fillAmount.Value;   
    }

    float fillProgress()
    {
        switch (Currentlevel.Value)
        {
            case 1:

                fillAmount.Value = CurrentKillCount.Value * 0.0058f;
                break;
            case 2:
                fillAmount.Value = checkPoint1 + ((CurrentKillCount.Value - 50) * 0.0056f);
                break;
            case 3:
                fillAmount.Value = checkPoint2 + ((CurrentKillCount.Value - 100) * 0.0086f);
                break;
        }
        return fillAmount.Value;
    }
}
