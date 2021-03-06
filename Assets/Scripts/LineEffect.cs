﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEffect : MonoBehaviour
{
    private float alpha = 1;
    private float target = 0;
    private float speed = 2f;
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Sprites/Default"));
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha >= target)
        {
            target = 0;
        }

        if (alpha <= target)
        {
            target = 1;
        }
        
        if (alpha < target && target > 0.9f)
        {
            alpha += Time.deltaTime * speed;
        }

        if (alpha > target && target < 0.1f)
        {
            alpha -= Time.deltaTime * speed;
        }

        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.green, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        line.colorGradient = gradient;
    }
}
