using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorruptedHeart : MonoBehaviour
{
    public static CorruptedHeart instance;

    private Animator HeartBeat;
    public IntVariable CurrentHealth;
    public FloatVariable HeartColor;

    private SpriteRenderer heart;
    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<SpriteRenderer>();
        HeartBeat = GetComponent<Animator>();
        instance = this;
        heart.color = Color.Lerp(Color.red, Color.black, instance.HeartColor.Value);
    }

    void Update()
    {
        switch(CurrentHealth.Value)
        {
            case 1: case 2:
                HeartBeat.speed = 5;
                break;
            case 3: case 4:
                HeartBeat.speed = 4;
                break;
            case 5: case 6:
                HeartBeat.speed = 3;
                break;
            case 7: case 8:
                HeartBeat.speed = 2;
                break;
            case 9: case 10:
                HeartBeat.speed = 1;
                break;
        }
    }

    public static void Darken()
    {
        instance.HeartColor.Value += 0.01f;
        instance.heart.color = Color.Lerp(Color.red, Color.black, instance.HeartColor.Value);
    }
}