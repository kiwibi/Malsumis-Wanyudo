using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "DamageType/DamageType")]
public class DamageType : ScriptableObject
{
    [Tooltip("The objects which take damage from this object.")]
    public List<DamageType> DefeatedTypes = new List<DamageType>();
}