using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnHit : MonoBehaviour
{
  
    public GameObject Blood;

    void Start()
    {

    }

    public void Flash()
    {
        StartCoroutine(RedFlash());
    }

    public void BloodSpawn()
    {
        var blood_pool = Instantiate(Blood, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation, GameObject.Find("GameArea/background/blood").transform);
        Destroy(blood_pool, 5);
    }

    IEnumerator RedFlash()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
