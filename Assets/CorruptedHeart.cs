using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorruptedHeart : MonoBehaviour
{
    public static CorruptedHeart instance;

    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        instance = this;
    }

    public static void Darken()
    {
        instance.image.color = new Color(instance.image.color.r - 0.02f, instance.image.color.g, instance.image.color.b);       
    }
}
