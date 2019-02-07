using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        if (other.gameObject.tag == "Enemy")
        {
            Player.gameObject.GetComponent<PlayerStats>().DealDamage(1);
        }
    }
}
