using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnEnabled : MonoBehaviour
{
    public bool growOnStart;

    public float growSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (growOnStart)
        {
            transform.localScale = new Vector3(0,0,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < 2 && transform.localScale.y < 2)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime * growSpeed;
        }
        else
        {
            transform.localScale = new Vector3(2,2,1);
        }
    }
}
