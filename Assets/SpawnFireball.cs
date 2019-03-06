using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour
{
    public bool spawning;
    
    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            if (transform.localScale.x < 0.5f)
            {

                transform.localScale += new Vector3(0.01f, 0.01f, 0);
            }
            else
            {
                transform.localScale = new Vector3(0.3f, 0.3f, 0);
            }
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
