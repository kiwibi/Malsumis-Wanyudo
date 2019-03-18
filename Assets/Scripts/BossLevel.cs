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
            SceneManager.LoadScene(loseScreen.Value);
        }

        if (alienHealth.Value <= 0)
        {
            SceneManager.LoadScene(winScreen.Value);
        }
    }
}
