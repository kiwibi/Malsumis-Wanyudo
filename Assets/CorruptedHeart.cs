using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorruptedHeart : MonoBehaviour
{
    public static CorruptedHeart instance;

    private Animator HeartBeat;
    public IntVariable CurrentHealth;

    private SpriteRenderer heart;
    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<SpriteRenderer>();
        HeartBeat = GetComponent<Animator>();
        instance = this;
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
        //var bar = GameObject.Find("UI/Corruption/Fill Area/Fill").GetComponent<Image>();
        instance.heart.color = new Color(instance.heart.color.r - 0.01f, instance.heart.color.g, instance.heart.color.b);
        //bar.color = new Color(bar.color.r, bar.color.g, bar.color.b);
    }
}