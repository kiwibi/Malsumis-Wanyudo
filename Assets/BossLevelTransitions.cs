using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelTransitions : MonoBehaviour
{
    public StringVariable BossLevel;
    public StringVariable TitleScreen;
    public void StartGame()
    {
        SceneManager.LoadScene(BossLevel.Value);
    }

    public void Quit()
    {
        SceneManager.LoadScene(TitleScreen.Value);
    }
}
