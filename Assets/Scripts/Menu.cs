using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public StringVariable Level1;
    public StringVariable Controls;
    public StringVariable Credit;

    public void StartGame()
    {
        EventManager.TriggerEvent("MenuClick");
        SceneManager.LoadScene(Level1.Value);
    }

    public void ControlScreen()
    {
        EventManager.TriggerEvent("MenuClick");
        SceneManager.LoadScene(Controls.Value);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        EventManager.TriggerEvent("MenuClick");
        SceneManager.LoadScene(Credit.Value);
    }
}
