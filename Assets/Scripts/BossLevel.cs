using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevel : MonoBehaviour
{
    public StringVariable loseScreen;
    public StringVariable titleScreen;
    public StringVariable winScreen;
    public IntVariable currentLevel;
    public IntVariable playerHealth;
    public IntVariable alienHealth;
    public Animator anim;

    public float loseDelay;
    public float winDelay;
    // Start is called before the first frame update
    void Start()
    {
        if (anim == null)
        {
            Debug.LogError("Missing animator");
        }

        currentLevel.Value = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.Value <= 0)
        {
           StartCoroutine(WinScreen(loseScreen.Value, loseDelay));
        }

        if (alienHealth.Value <= 0)
        {
            StartCoroutine(WinScreen(winScreen.Value, winDelay));
        }
    }

    private IEnumerator WinScreen(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
