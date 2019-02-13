using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour
{
    private Vector3 originalPos;
    public static ShakeBehaviour instance;

    public FloatReference duration;
    public FloatReference magnitude;

    public static float duration_;
    public static float magnitude_;



    void Awake()
    {
        originalPos = transform.localPosition;
        duration_ = duration.Value;
        magnitude_ = magnitude.Value;
        instance = this;
    }

    public static void Shake()
    {
        instance.originalPos = instance.gameObject.transform.localPosition;
        instance.StartCoroutine(instance.cShake(duration_, magnitude_));
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
