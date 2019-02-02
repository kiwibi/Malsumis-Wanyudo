using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyDirection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehavior behavior = collision.gameObject.GetComponent<EnemyBehavior>();
        if (behavior != null)
        {
            behavior.strafeDirection *= -1;
        }

    }
}
