using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLight : MonoBehaviour
{
    private Light starLight;
    public int minIntensity;
    public int maxIntensity;
    public float intensitySpeed;
    public bool intensityUp;

    // Start is called before the first frame update
    void Start()
    {
        starLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (intensityUp == true){
            starLight.intensity = starLight.intensity + Time.deltaTime*intensitySpeed;
        }
        if (starLight.intensity < minIntensity)
        {
            intensityUp = true;
        }
        if (starLight.intensity > maxIntensity)
        {
            intensityUp = false;
        }
        if (intensityUp == false)
        {
            starLight.intensity = starLight.intensity - Time.deltaTime*intensitySpeed;
        }
            
        // if intensity is smaller than maxIntensity
        // make intensity bigger

        // if intensity is bigger than maxIntensity
        // change instensityUp to false

        // if intensityUp false
        // do same thing other way
    }
}