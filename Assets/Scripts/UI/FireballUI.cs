using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballUI : MonoBehaviour
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
        FireballUI.animated = false;
        background = GetComponent<Image>();
        textField = GetComponentInChildren<Text>();
        startAnimation = GetComponent<ScaleMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alienStats.AlienLevel < 3)
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
            if(FireballUI.animated == true)
            {
                startAnimation.enabled = false;
            }
            else
            {
                startAnimation.enabled = true;
            }
        }
        
        if (alienStats.FireballOnCooldown)
        {
            if (!counting)
            {
                coolDownDuration = alienStats.FireballCooldown;
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
