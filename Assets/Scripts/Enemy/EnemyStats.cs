using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    public IntVariable KillCount;
    public FloatReference MinShootDelay;
    public FloatReference MaxShootDelay;
    public FloatReference Speed;
    public FloatReference StrafeSpeed;
    public FloatReference MinChangeDirectionDelay;
    public FloatReference MaxChangeDirectionDelay;
    public IntReference MaxHP;
    
    [Header("Sounds")]
    public SimpleAudioEvent hurtSound;
    public SimpleAudioEvent shootGunSound;
    
    private int m_Health;
    private DamageFeedback hitFlash;
    private AudioPlayer audioPlayer;

    void Start()
    {
        m_Health = MaxHP;
        hitFlash = GetComponentInChildren<DamageFeedback>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    void Update()
    {
        if(m_Health <= 0)
        {
            hitFlash.BloodSpawn();
            Die();
        }
    }

    public override void DealDamage(int value) {
        hitFlash.Knockback();
        hitFlash.Flash();
        m_Health -= value;
        PlayHurtSound();
    }
    
    
    public void PlayHurtSound()
    {
        audioPlayer.AudioEvent = hurtSound;
        audioPlayer.PlaySound();
    }

    public override void Die()
    {
        //Debug.Log("Enemy health: " + KillCount.Value);
        KillCount.Value++;
        Destroy(gameObject);
    }
}
