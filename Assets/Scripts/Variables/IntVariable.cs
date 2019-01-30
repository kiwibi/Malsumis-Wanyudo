using System;
using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject
{
    public int Value;

    // Allow IntVariable to be converted to int
    public static explicit operator int(IntVariable v)
    {
        return v.Value;
    }
}
