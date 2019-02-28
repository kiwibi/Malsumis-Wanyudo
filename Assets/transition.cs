using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    public static bool fading;

    private LevelFade fadeEffects;
    // Update is called once per frame
    void Start()
    {
        fadeEffects = GetComponent<LevelFade>();
    }

    void Update()
    {
        if (Input.anyKeyDown && fading != true)
        {
            
            fading = true;
            fadeEffects.StartFade();
        }
    }
}
