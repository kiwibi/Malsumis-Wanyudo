﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightDistance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
