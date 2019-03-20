using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    public static bool animated;

    public AlienStatsObject alienStats;
    public GameObject titleField;
    
    private Image background;
    private Text textField;
    private ScaleMove startAnimation;
    
    private bool counting = false;
    private float coolDownDuration = 0;
    // Start is called before the first frame update
    void Start()
    {
        DashUI.animated = false;
        background = GetComponent<Image>();
        textField = GetComponentInChildren<Text>();
        startAnimation = GetComponent<ScaleMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alienStats.AlienLevel < 2)
        {
            background.enabled = false;
            textField.enabled = false;
            titleField.GetComponent<Text>().enabled = false;
            startAnimation.enabled = false;
        }
        else
        {
            background.enabled = true;
            textField.enabled = true;
            titleField.GetComponent<Text>().enabled = true;
            if (DashUI.animated == true)
            {
                startAnimation.enabled = false;
            }
            else
            {
                startAnimation.enabled = true;
            }
        }

        if (alienStats.DashOnCooldown)
        {
            if (!counting)
            {
                coolDownDuration = alienStats.DashCooldown;
                counting = true;
            }
            
            background.color = Color.grey;
            coolDownDuration -= Time.deltaTime;
            textField.text = Mathf.CeilToInt(coolDownDuration).ToString();
        }
        else
        {
            background.color = Color.white;
            textField.text = "";
            counting = false;
        }
    }
}
