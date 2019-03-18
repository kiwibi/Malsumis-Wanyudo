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
            case 1:
                anim.SetInteger("Level", 1);
                break;
            case 2:
                anim.SetInteger("Level", 2);
                break;
            case 3:
                anim.SetInteger("Level", 3);
                break;
            case 4: 
                anim.SetInteger("Level", 4);
                break;
        }
    }
}
