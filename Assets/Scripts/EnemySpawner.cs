using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public FloatVariable SpawnDelay;
    public GameObject Enemy;

    public SpawnPoint[] spawnPoints;

    void Start()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        InvokeRepeating("Spawn", (float)SpawnDelay, (float)SpawnDelay);
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(Enemy, spawnPoints[spawnPointIndex].transform);
    }
}
