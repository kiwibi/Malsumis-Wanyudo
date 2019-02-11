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
        GetComponent<SpriteRenderer>().sprite = Bloodpools[index];
    }
}
