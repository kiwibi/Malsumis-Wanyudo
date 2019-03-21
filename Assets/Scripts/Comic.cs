using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comic : MonoBehaviour
{
    public Sprite[] panels;
    private Image currentPanel;

    private GameObject transition;
    private int panelCount;

    // Start is called before the first frame update
    void Start()
    {
        transition = GameObject.Find("transitionController/Canvas/introtext");
        currentPanel = GetComponent<Image>();
        currentPanel.sprite = panels[0];
        panelCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transition.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else if(Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Fire1"))
        {
            if((panelCount + 1) < panels.Length)
            {
                panelCount++;
                currentPanel.sprite = panels[panelCount];
            }
            else
            {
                transition.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
