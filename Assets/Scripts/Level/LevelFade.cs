using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFade : MonoBehaviour
{
    public IntReference BlackoutTimer;
    public FloatReference FadeInSpeed;

    private bool fadedIn;
    private CanvasGroup transitionCanvas;
    

    void Start()
    {
        transitionCanvas = GetComponentInChildren<CanvasGroup>();
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
        StartCoroutine(Fade());
        yield return new WaitForSecondsRealtime(BlackoutTimer.Value);
        StartCoroutine(Fade());
        
    }

    IEnumerator Fade()
    {
        if (fadedIn == false)
        {
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                transitionCanvas.alpha = f;
                yield return new WaitForSecondsRealtime(FadeInSpeed);
            }
            transitionCanvas.alpha = 0;
            fadedIn = true;
        }
        else if (fadedIn == true)
        {
            for (float f = 0f; f <= 1f; f += 0.1f)
            {
                transitionCanvas.alpha = f;
                yield return new WaitForSecondsRealtime(.1f);
                
            }
            transitionCanvas.alpha = 1;
            fadedIn = false;
        }
    }
}
