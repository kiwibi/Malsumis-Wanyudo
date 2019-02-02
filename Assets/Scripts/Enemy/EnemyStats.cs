using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public IntReference MaxHP;
    public FloatReference MinShootDelay;
    public FloatReference MaxShootDelay;
    public FloatReference Speed;
    public FloatReference StrafeSpeed;
    public FloatReference MinChangeDirectionDelay;
    public FloatReference MaxChangeDirectionDelay;

    private int m_HP;

    public int HP { get => m_HP; set => m_HP = value; }

    private void Start()
    {
        m_HP = MaxHP.Value;
    }
}
