using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public FloatVariable MinSpawnDelay;
    public FloatVariable MaxSpawnDelay;
    public GameObject Enemy;
    public BoolVariable SpawnerOn;

    public SpawnPoint[] spawnPoints;

    IEnumerator Start()
    {
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        while (SpawnerOn.Value)
        {
            yield return new WaitForSeconds(Random.Range(MinSpawnDelay.Value, MaxSpawnDelay.Value));
            Spawn();
        }
    }

    void Spawn()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(Enemy, spawnPoints[spawnPointIndex].transform);
    }
}
