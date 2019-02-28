using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevel : MonoBehaviour
{
    public StringVariable loseScreen;
    public StringVariable titleScreen;
    public StringVariable winScreen;
    public IntVariable playerHealth;
    public IntVariable alienHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
