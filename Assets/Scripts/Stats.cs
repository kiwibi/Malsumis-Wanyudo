using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    public abstract void DealDamage(int value);

    public abstract void Die();
}
