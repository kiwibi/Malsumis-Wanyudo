using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    public static bool fading;

    private flashingText[] fadeEffects;

    public FloatVariable seconds;
    // Update is called once per frame
    void Start()
    {
        fadeEffects = GetComponentsInChildren<flashingText>();
    }

    void Update()
    {
        if (Input.anyKeyDown && fading != true)
        {
            fading = true;
            foreach(var fadeEffect in fadeEffects)
            {
                fadeEffect.StartFadeOut(seconds.Value);
            }
            StartCoroutine(changeScene());
        }
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene("Level1");
    }
}
