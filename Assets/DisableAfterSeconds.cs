using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterSeconds : MonoBehaviour
{
    public float disableAfterSeconds;
    void Start()
    {
        StartCoroutine("Disable");
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(disableAfterSeconds);
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<DamageDealer>().enabled = false;
        gameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;
    }
}
