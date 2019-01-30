using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float Value;

    // Allow FloatVariable to be converted to float
    public static explicit operator float(FloatVariable v)
    {
        return v.Value;
    }
}
