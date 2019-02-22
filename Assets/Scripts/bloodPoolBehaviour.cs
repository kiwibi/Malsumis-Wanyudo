using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodPoolBehaviour : MonoBehaviour
{
    public Sprite[] Bloodpools;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, Bloodpools.Length);
        GetComponentInChildren<SpriteRenderer>().sprite = Bloodpools[index];
        float angle = Random.Range(0.0f, 359.9f);
        Vector3 up = new Vector3(0, 0, 1);
        var rotation = Quaternion.AngleAxis(angle, up);
        rotation.x = 0;
        rotation.y = 0;
        transform.rotation = rotation;
    }
}
