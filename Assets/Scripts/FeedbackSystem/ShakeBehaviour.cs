using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour
{
    private float camSize;
    public static ShakeBehaviour instance;

    public FloatReference duration;
    public FloatReference magnitude;

    public static float duration_;
    public static float magnitude_;

    public static bool isShaking;


    void Awake()
    { 
        duration_ = duration.Value;
        magnitude_ = magnitude.Value;
        instance = this;
        ShakeBehaviour.isShaking = false;

    }

    public static void Shake()
    {
        ShakeBehaviour.isShaking = true;
        instance.camSize = Camera.main.orthographicSize;
        instance.StartCoroutine(instance.cShake(duration_, magnitude_));
    }

    public IEnumerator cShake(float duration, float magnitude)
    {
        
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            Camera.main.orthographicSize = Random.Range(4.5f,5.0f);

            duration -= Time.deltaTime;

            yield return null;
        }

        Camera.main.orthographicSize = camSize;
        ShakeBehaviour.isShaking = false;
    }
}
