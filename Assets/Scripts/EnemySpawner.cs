using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public FloatReference MinSpawnDelay;
    public FloatReference MaxSpawnDelay;
    public IntVariable NumberOfEnemies1;
    public IntVariable NumberOfEnemies2;
    public IntVariable NumberOfEnemies3;
    public IntVariable CurrentLevel;
    
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public BoolVariable SpawnerOn;
    public SpawnPoint[] spawnPoints;

    private Level level;
    private int maxRange;
    
    IEnumerator Start()
    {
        SpawnerOn.Value = true;
        level = GameObject.FindGameObjectWithTag("Level").GetComponent<Level>();
        spawnPoints = GetComponentsInChildren<SpawnPoint>();

        if (CurrentLevel.Value == 1)
        {
            maxRange = 5;
        }
        
        else if (CurrentLevel.Value == 2)
        {
            maxRange = 9;
        }
        else if (CurrentLevel.Value == 3)
        {
            maxRange = 11;
        }
        
        
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
        int enemyType = Random.Range(1, maxRange);
        switch(enemyType)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:       
                return Enemy1;
            case 6:
            case 7:
            case 8:
                return Enemy2;
            case 9:
            case 10:
                return Enemy3;
            default:
                return Enemy1;
        }
    }
}
