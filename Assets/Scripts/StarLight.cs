using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLight : MonoBehaviour
{
    private Light light;
    public int minIntensity;
    public int maxIntensity;
    public bool intensityUp;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // if intensityUp true
        // if intensity is smaller than maxIntensity
        // make intensity bigger

        // if intensity is bigger than maxIntensity
        // change instensityUp to false

        // if intensityUp false
        // do same thing other way
    }
}