using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;

public class MoveFireBall : MonoBehaviour
{
    public FloatReference FireballSpeed;
    
    void Update()
    {
        transform.Translate(Vector3.up * FireballSpeed * Time.deltaTime);
    }
}
