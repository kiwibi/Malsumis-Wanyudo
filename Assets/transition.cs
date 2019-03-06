using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    public IntVariable currentLevel;

    // Update is called once per frame
    void Start()
    {

        if (currentLevel == null)
        {
            Debug.LogError("currentLevel missing");
        }

    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (currentLevel.Value > 3)
            {
                SceneManager.LoadScene("BossLevel");
            }
            else
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
