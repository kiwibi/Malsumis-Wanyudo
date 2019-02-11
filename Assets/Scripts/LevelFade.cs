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
        StartCoroutine(Fade());
        Time.timeScale = 1;
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
            fadedIn = false;
        }
        else if (fadedIn == false)
        {
            for (float f = 0f; f <= 1; f += 0.1f)
            {
                transitionCanvas.alpha = f;
                yield return new WaitForSecondsRealtime(.1f);
            }
            fadedIn = true;
        }
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemies)
        {
            enemy.GetComponent<Stats>().DealDamage(10);
        }
    }
}
