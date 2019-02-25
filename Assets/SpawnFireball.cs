using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour
{
    public bool spawning;
    
    // Update is called once per frame
    void Update()
    {
        if (spawning &&  transform.localScale.x < 2)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
