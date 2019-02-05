using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public IntReference DamageAmount;
    public GameObject Parent;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && Parent.gameObject.tag != "Enemy")
        {
            col.gameObject.GetComponent<EnemyStats>().HP -= DamageAmount.Value;
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Player" && Parent.gameObject.tag != "Player")
        {
            col.gameObject.GetComponent<PlayerStats>().Health -= DamageAmount.Value;
            Destroy(gameObject);
        }
    }
}