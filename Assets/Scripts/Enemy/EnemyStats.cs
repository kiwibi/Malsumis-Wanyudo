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
    public SimpleAudioEvent deathSound;
    public SimpleAudioEvent shootGunSound;
    
    private int m_Health;
    private AudioPlayer audioPlayer;
    private DamageFeedback dmgFeedback;

    void Start()
    {
        m_Health = MaxHP;
        audioPlayer = GetComponent<AudioPlayer>();
        dmgFeedback = GetComponentInChildren<DamageFeedback>();
    }

    void Update()
    {
        if(m_Health <= 0)
        {
            dmgFeedback.BloodSpawn();
            Die();
        }
    }

    public override void DealDamage(int value) {
        dmgFeedback.OnHit();
        m_Health -= value;
        if (m_Health <= 0)
        {
            PlayDeathSound();
        }
        else
        {
            PlayHurtSound();
        }
    }
    
    
    public void PlayHurtSound()
    {
        audioPlayer.AudioEvent = hurtSound;
        audioPlayer.PlaySound();
    }

    public void PlayDeathSound()
    {
        audioPlayer.AudioEvent = deathSound;
        audioPlayer.PlaySound();
    }

    public override void Die()
    {
        KillCount.Value++;
        Destroy(gameObject);
        //Debug.Log("Enemy health: " + KillCount.Value);
    }
}
