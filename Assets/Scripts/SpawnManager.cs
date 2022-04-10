using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    // TODO: add mutliple enemy type
    // public GameObject[] enemyPrefab;
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;

    public int enemyCount;
    public int waveCount = 1;

    // Start is called before the first frame update
    void Start() 
    {
        SpawnEnemyWave(waveCount);
    }

    // Update is called once per frame
    void Update() 
    {
        CheckEnemyWave();
    }

    void CheckEnemyWave()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector2 randomPosition = spawnPoints[randomIndex].transform.position;

        return randomPosition;
    }
}
