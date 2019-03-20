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

    private AudioPlayer audioPlayer;


    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevel == 1 && KillCounter >= ClearCondition_1)
        {

            StartCoroutine(Evolve1());
        }

        if (currentLevel == 2 && KillCounter >= ClearCondition_2)
        {
            
            StartCoroutine(Evolve2());
        }
    }

    private IEnumerator Evolve1()
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool( "Evolve1", true);
        audioPlayer.AudioEvent = evolve1;
        audioPlayer.PlaySound();
    }
    
    private IEnumerator Evolve2()
    {
        yield return new WaitForSeconds(delay);
        audioPlayer.AudioEvent = evolve2;
        audioPlayer.PlaySound();
        anim.SetBool( "Evolve2", true);
    }
}
