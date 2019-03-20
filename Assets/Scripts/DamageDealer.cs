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
            if (col.CompareTag("Shield") && gameObject.CompareTag("Bullet"))
            {
                Destroy(gameObject);
                return;
            }
            
            if (damageDealer.damageType.TakesDamageFrom.Contains(damageType))
            {
                col.gameObject.GetComponent<Stats>().DealDamage(DamageAmount.Value);
                
                if(!gameObject.CompareTag("Alien"))
                {   
                    if (damageType.name == "Enemy")
                    {
                        ShakeBehaviour.Shake();
                    }
                    
                    if (!gameObject.CompareTag("Fireball"))
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}