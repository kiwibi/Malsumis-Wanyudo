﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoMenu : MonoBehaviour
{
    public StringVariable menu;

    void Update()
    {
        if(Input.GetKey("escape"))
        {
            EventManager.TriggerEvent("MenuClick");
            SceneManager.LoadScene(menu.Value);
        }
    }

    public void GoBackButton()
    {
        EventManager.TriggerEvent("MenuClick");
        SceneManager.LoadScene(menu.Value);
    }
}
