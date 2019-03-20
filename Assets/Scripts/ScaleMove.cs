using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleMove : MonoBehaviour
{
    private Image background;

    private Vector3 targetPos;
    
    private Vector3 TargetScale;

    private float speed;

    // Start is  called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        speed = 30;
        //movement
        targetPos = background.transform.position;
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        background.transform.position = screenPos;
        //Scale
        background.transform.localScale = new Vector3(5, 5, 0);
        TargetScale = new Vector3(1, 1, 1);
    }
    void Update()
    {
        ScaleAndMove();
    }

    public void ScaleAndMove()
    {
        if (Vector3.Distance(background.transform.position, targetPos) > 0.1f)
        {
            //move
            float step = speed * 1.5f * Time.unscaledDeltaTime;
            background.transform.position = Vector3.MoveTowards(background.transform.position, targetPos, step);
            //Scale
            step = speed / 12 * Time.unscaledDeltaTime;
            background.transform.localScale = Vector3.MoveTowards(background.transform.localScale, TargetScale, step);
        }
        else if (Vector3.Distance(background.transform.position,targetPos) < 0.1f)
        {
            DashUI.animated = true;
            FireballUI.animated = true;
        }
    }
}
