using UnityEngine;

public class AlienStats : Stats
{
    public IntVariable AlienMaxHealth;
    public IntVariable AlienHealth;

    private int nextSpeedUp;
    private AlienStatsObject stats;
    private readonly int speedUpSteps = 10;
    private Light light;

    // Start is called before the first frame update
    private void Start()
    {
        stats = GetComponent<StateController>().stats;
        light = GetComponentInChildren<Light>();
        light.intensity = 5;
        AlienHealth.Value = AlienMaxHealth.Value;
        stats.FireballCooldown = stats.StartFireballCooldown;
        stats.FireballOnCooldown = true;
        stats.DashCooldown = stats.StartDashCooldown;
        stats.DashOnCooldown = true;
        nextSpeedUp = AlienHealth.Value - speedUpSteps;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public override void DealDamage(int damage)
    {
        AlienHealth.Value -= damage;
        if (AlienHealth.Value <= 0)
        {
            Die();
        }

        if (AlienHealth.Value <= nextSpeedUp)
        {
            nextSpeedUp -= speedUpSteps;
            ChangeAttackSpeeds(0.1f);
            DimLights(1);
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    private void DimLights(int intensity)
    {
        light.intensity -= intensity;
    }

    private void ChangeSpeed(float speed)
    {
        stats.AlienSpeed += speed;
    }

    private void ChangeAttackSpeeds(float speed)
    {
        stats.FireballMinCooldown -= speed;
        stats.FireballMaxCooldown -= speed;
        stats.DashCooldown -= speed;
    }
}
