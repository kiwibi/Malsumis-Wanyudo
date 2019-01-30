using UnityEngine;

[SerializeField]
public class FloatReference : ScriptableObject
{
    public bool UseConstant = true;
    public float ConstantValue;
    public FloatVariable Variable;

    public float Value => UseConstant ? ConstantValue : Variable.Value;
}
