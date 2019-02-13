using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenMenu : MonoBehaviour
{
    public StringVariable Level1;
    public StringVariable TitleScreen;
    public void StartGame()
    {
        SceneManager.LoadScene(Level1.Value);
    }

    public void Quit()
    {
        SceneManager.LoadScene(TitleScreen.Value);
    }
}
