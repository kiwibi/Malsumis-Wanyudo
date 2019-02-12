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
        transitionCanvas = GetComponent<CanvasGroup>();
        fadedIn = false;
    }

    public void StartFade()
    {
        StartCoroutine(levelTransition());
    }

    IEnumerator levelTransition()
    {
        StartCoroutine(Fade());
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(BlackoutTimer.Value);
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Time.timeScale = 1;
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Stats>().DealDamage(10);
        }
        StartCoroutine(Fade());
        
    }

    IEnumerator Fade()
    {
        if (fadedIn == true)
        {
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                transitionCanvas.alpha = f;
                yield return new WaitForSecondsRealtime(FadeInSpeed);
            }
            transitionCanvas.alpha = 0;
            fadedIn = false;
        }
        else if (fadedIn == false)
        {
            for (float f = 0f; f <= 1f; f += 0.1f)
            {
                transitionCanvas.alpha = f;
                yield return new WaitForSecondsRealtime(.1f);
                
            }
            transitionCanvas.alpha = 1;
            fadedIn = true;
        }
    }
}
