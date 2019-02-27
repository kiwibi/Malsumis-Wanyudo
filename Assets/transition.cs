using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    private LevelFade fadeEffects;
    // Update is called once per frame
    void Start()
    {
        fadeEffects = GetComponent<LevelFade>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //skip forward or leave scene
        }
    }
}
