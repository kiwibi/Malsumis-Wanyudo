using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public FloatVariable MinSpawnDelay;
    public FloatVariable MaxSpawnDelay;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public BoolVariable SpawnerOn;
    public SpawnPoint[] spawnPoints;

    private Level level;

    IEnumerator Start()
    {
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<Level>();
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

        Instantiate(GetEnemyType(), spawnPoints[spawnPointIndex].transform);
    }

    GameObject GetEnemyType()
    {
        int maxEnemyType = level.currentLevel.Value + 1;
        int enemyType = Random.Range(1, maxEnemyType);
        switch(enemyType)
        {
            case 1:
                return Enemy1;
            case 2:
                return Enemy2;
            case 3:
                return Enemy3;
            default:
                Debug.LogWarning("Trying to spawn wrong enemy type");
                return Enemy1;
        }
    }
}
