using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOnEnabled : MonoBehaviour
{
    public bool growOnStart;
    public float endScale;
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
        if (transform.localScale.x < endScale && transform.localScale.y < endScale)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime * growSpeed;
        }
        else
        {
            transform.localScale = new Vector3(endScale,endScale,1);
        }
    }
}
