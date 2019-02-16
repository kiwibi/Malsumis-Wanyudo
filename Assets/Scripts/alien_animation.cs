using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_animation : MonoBehaviour
{
    public Animator anim;
    public IntReference currentLevel;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch(currentLevel.Value)
        {
            case 2:
                anim.SetBool("Stage2", true);
                break;
            case 3:
                break;
        }
    }
}
