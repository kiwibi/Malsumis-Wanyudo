using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public IntVariable MaxHP;
    public FloatVariable MinShootDelay;
    public FloatVariable MaxShootDelay;
    public FloatVariable Speed;
    public FloatVariable StrafeSpeed;
    public FloatVariable MinChangeDirectionDelay;
    public FloatVariable MaxChangeDirectionDelay;

    private int m_HP;

    public int HP { get => m_HP; set => m_HP = value; }

    private void Start()
    {
        m_HP = MaxHP.Value;
    }
}
