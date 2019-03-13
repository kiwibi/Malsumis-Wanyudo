using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour
{
    public IntReference KillCounter;
    public IntReference ClearCondition_1;
    public IntReference ClearCondition_2;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (KillCounter >= ClearCondition_1)
        {
            anim.SetBool( "Evolve1", true);
        }

        if (KillCounter >= ClearCondition_2)
        {
            anim.SetBool( "Evolve2", true);
        }
    }
}
