using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public StringVariable titleScreen;
    public GameObject PauseMenuUI;

    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Pause();
        }

        if(isPaused == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(titleScreen.Value); 
    }
}
