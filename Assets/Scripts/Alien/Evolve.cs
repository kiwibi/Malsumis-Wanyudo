using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour
{
    public IntReference currentLevel;
    public IntReference KillCounter;
    public IntReference ClearCondition_1;
    public IntReference ClearCondition_2;
    public float delay;
    public SimpleAudioEvent evolve1;
    public SimpleAudioEvent evolve2;

    private AudioSource audioSource;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel == 1 && KillCounter >= ClearCondition_1)
        {
            evolve1.Play(audioSource);
            StartCoroutine(Evolve1());
        }

        if (currentLevel == 2 && KillCounter >= ClearCondition_2)
        {
            evolve2.Play(audioSource);
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
