using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag == "Enemy")
        {
            playerStats.DealDamage(1);
        }
    }
}
