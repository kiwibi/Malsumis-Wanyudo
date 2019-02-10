using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public StringVariable titleScreen;
    public IntVariable currentLevel;
    public IntVariable KillCounter;
    //Clear first lvl
    public IntReference ClearCondition_1;
    //Clear second lvl
    public IntReference ClearCondition_2;
    //Clear third and entern boss lvl
    public IntReference ClearCondition_3;

    private bool fadedIn;
    private GameObject transitionCanvas;
    private GameObject transitionChild;
    private Renderer transitionRenderer;

    void Start()
    {
        KillCounter.Value = 0;
        currentLevel.Value = 1;
        transitionCanvas = GameObject.Find("Leveltransition");
        transitionChild = transitionCanvas.transform.GetChild(0).gameObject;
        fadedIn = false;
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(titleScreen.Value);
        }

        switch (currentLevel.Value)
        {
            case 1:
                if(KillCounter.Value >= ClearCondition_1.Value)
                {
                    StartCoroutine(levelTransition());
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                }
                break;
            case 2:
                if (KillCounter.Value >= ClearCondition_2.Value)
                {
                    currentLevel.Value += 1;
                    KillCounter.Value = 0;
                }
                break;
            case 3:
                if (KillCounter.Value >= ClearCondition_3.Value)
                {
                    //Disable mob spawner for bossfight
                    //or skip to boss scene
                    currentLevel.Value += 1;
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator levelTransition()
    {
        StartCoroutine(Fade());
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        StartCoroutine(Fade());
        Time.timeScale = 1;
    }

    IEnumerator Fade()
    {
        if (fadedIn == true)
        {
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                transitionChild.GetComponent<CanvasGroup>().alpha = f;
                yield return new WaitForSecondsRealtime(.1f);
            }
            fadedIn = false;
        }
        else if(fadedIn == false)
        {
            for (float f = 0f; f <= 1; f += 0.1f)
            {
                transitionChild.GetComponent<CanvasGroup>().alpha = f;
                yield return new WaitForSecondsRealtime(.1f);
            }
            fadedIn = true;
        }
    }
}
