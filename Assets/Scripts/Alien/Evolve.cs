using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour
{
    public IntReference KillCounter;
    public IntReference ClearCondition_1;
    public IntReference ClearCondition_2;
    public float delay;

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
            StartCoroutine(Evolve1());
        }

        if (KillCounter >= ClearCondition_2)
        {
            StartCoroutine(Evolve2());
        }
    }

    private IEnumerator Evolve1()
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool( "Evolve1", true);
    }
    
    private IEnumerator Evolve2()
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool( "Evolve2", true);
    }
}
