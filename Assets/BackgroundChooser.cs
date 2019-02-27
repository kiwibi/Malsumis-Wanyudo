using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChooser : MonoBehaviour
{

    public IntVariable currentLevel;
    private SpriteRenderer spriteRender;
    public Sprite[] BGsprites;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        switch(currentLevel.Value)
        {
            case 1:
                spriteRender.sprite = BGsprites[0];
                break;
            case 2:
                spriteRender.sprite = BGsprites[1];
                break;
            case 3:
                //spriteRender.sprite = BGsprites[2];
                break;
        }
    }
}
