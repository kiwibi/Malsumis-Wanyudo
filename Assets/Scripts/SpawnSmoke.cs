using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSmoke : MonoBehaviour
{
    private ParticleSystem particles;
    
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        particles.Play();
    }
}
