using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;

public class MoveFireBall : MonoBehaviour
{
    public FloatReference FireballSpeed;
    public bool MoveUp = true;
    void Update()
    {
        if(MoveUp)
        {
            transform.Translate(Vector2.up * FireballSpeed * Time.deltaTime);
        } else
        {
            transform.Translate(Vector2.down * FireballSpeed * Time.deltaTime);
        }

    }
}
