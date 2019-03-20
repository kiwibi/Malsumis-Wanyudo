using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    public IntReference MaxHP;
    public FloatReference speed;
    public FloatReference pistolCooldown;
    public FloatReference InvincibleFrameTime;
    public IntVariable CurrentHealth;
    public AudioClip shootGun;
    private DamageFeedback dmgFeedback;

    private bool IsHit;

    void Start()
    {
        IsHit = false;
        CurrentHealth.Value = MaxHP.Value;
        dmgFeedback = GetComponentInChildren<DamageFeedback>();
    }

    void Update()
    {
        //Debug.Log("Player health: " + CurrentHealth.Value);
        if (CurrentHealth.Value <= 0)
        {
            dmgFeedback.BloodSpawn();
            Die();
        }
    }

    public override void DealDamage(int value)
    {
        if (IsHit == false)
        {
            dmgFeedback.Flash();
            StartCoroutine(InvincibilityFrame());
            CurrentHealth.Value -= value;
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator InvincibilityFrame()
    {
        IsHit = true;
        yield return new WaitForSecondsRealtime(InvincibleFrameTime.Value);
        IsHit = false;
    }
}
