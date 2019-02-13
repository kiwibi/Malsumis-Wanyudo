using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour
{
    private Vector3 originalPos;
    public static ShakeBehaviour instance;

    void Awake()
    {
        originalPos = transform.localPosition;

        instance = this;
    }

    public static void Shake(float duration, float magnitude)
    {
        instance.originalPos = instance.gameObject.transform.localPosition;
        instance.StartCoroutine(instance.cShake(duration, magnitude));
    }

    public IEnumerator cShake(float duration, float magnitude)
    {
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * magnitude;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
