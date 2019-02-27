using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFade : MonoBehaviour
{
    public IntReference BlackoutTimer;
    public FloatReference FadeInSpeed;

    //public SpriteRenderer AlienPicture;
    //public Animator alien_anim;

    private bool fadedIn;
    private CanvasGroup transitionCanvas;
    

    void Start()
    {
        transitionCanvas = GetComponent<CanvasGroup>();
        //alien_anim = GetComponentInChildren<Animator>();
        fadedIn = false;
    }

    public void StartFade()
    {
        StartCoroutine(levelTransition());
    }

    public void StartScene()
    {  
        StartCoroutine(StartUP());
    }

    IEnumerator StartUP()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            transitionCanvas.alpha = f;
            yield return new WaitForSecondsRealtime(FadeInSpeed);
        }
        transitionCanvas.alpha = 0;
    }

    IEnumerator levelTransition()
    {
        //alien_anim.Play("Alien_transition1", -1, 0f);
        StartCoroutine(Fade());
        yield return new WaitForSecondsRealtime(BlackoutTimer.Value);
        StartCoroutine(Fade());
        
    }

    IEnumerator Fade()
    {
        //Color _tmpColor = AlienPicture.GetComponentInChildren<SpriteRenderer>().color;
        if (fadedIn == true)
        {
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                transitionCanvas.alpha = f;
              //  GetComponentInChildren<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, f);
                yield return new WaitForSecondsRealtime(FadeInSpeed);
            }
            //GetComponentInChildren<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, 0);
            transitionCanvas.alpha = 0;
            fadedIn = false;
        }
        else if (fadedIn == false)
        {
            for (float f = 0f; f <= 1f; f += 0.1f)
            {
                transitionCanvas.alpha = f;
               // GetComponentInChildren<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, f);
                yield return new WaitForSecondsRealtime(.1f);
                
            }
            //GetComponentInChildren<SpriteRenderer>().color = new Color(_tmpColor.r, _tmpColor.g, _tmpColor.b, 1);
            transitionCanvas.alpha = 1;
            fadedIn = true;
        }
    }
}
