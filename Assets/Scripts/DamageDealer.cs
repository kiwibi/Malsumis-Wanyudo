using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public IntReference DamageAmount;
    [Tooltip("Damage type of this object.")]
    public DamageType damageType;
    
    void OnTriggerEnter2D(Collider2D col)
     {
        DamageDealer damageDealer = col.gameObject.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            //Debug.Log(damageType.name + " hit: " + damageDealer.damageType.name);
            if (damageDealer.damageType.TakesDamageFrom.Contains(damageType))
            {
                col.gameObject.GetComponent<Stats>().DealDamage(DamageAmount.Value);
                
                if(!gameObject.CompareTag("Alien"))
                {
                    if (damageType.name == "Fireball" || damageType.name == "Enemy")
                    {
                        ShakeBehaviour.Shake();
                    }
                    Destroy(gameObject);
                }
            }
        }
        /*
        if (m_owner != col.gameObject && col.gameObject.tag != "Alien")
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<EnemyStats>().DealDamage(DamageAmount.Value);
                Destroy(gameObject);
            }
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerStats>().DealDamage(DamageAmount.Value);
                Destroy(gameObject);
            }
        }
        */
    }
}