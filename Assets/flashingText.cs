using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashingText : MonoBehaviour
{


    Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = GetComponents<Text>();
    }

    public void StartFadeOut(float seconds)
    {
        foreach (var text in texts)
        {
            StartCoroutine(FadeOut(seconds, text));
        }
    }

    public void StartFadeIn(float seconds)
    {
        foreach (var text in texts)
        {
            StartCoroutine(FadeIn(seconds, text));
           
        }
    }

    IEnumerator FadeOut(float seconds, Text text)
    {
       
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.g, f);
                yield return new WaitForSecondsRealtime(seconds);

            }
            text.color = new Color(text.color.r, text.color.g, text.color.g, 0);
    }

    IEnumerator FadeIn(float seconds, Text text)
    {
            for (float f = 0f; f >= 1; f += 0.1f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.g, f);
                yield return new WaitForSecondsRealtime(seconds);
            }
            text.color = new Color(text.color.r, text.color.g, text.color.g, 1);
    }
}
