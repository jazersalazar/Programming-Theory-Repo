using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    public GameObject[] enemyPrefab;
    public GameObject[] specialPrefab;
    public GameObject[] spawnPoints;
    public GameObject[] droppablesPrefab;

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
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

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
            // Summon special zombie with 20% chance
            bool summonSpecial = Random.Range(0f, 100.0f) >= 80f ? true : false;
            if (summonSpecial)
            {
                int index = Random.Range(0, specialPrefab.Length);
                Instantiate(specialPrefab[index], GenerateSpawnPosition(), specialPrefab[index].transform.rotation);
            } else {
                int index = Random.Range(0, enemyPrefab.Length);
                Instantiate(enemyPrefab[index], GenerateSpawnPosition(), enemyPrefab[index].transform.rotation);
            }
        }
    }

    private Vector2 GenerateSpawnPosition()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector2 randomPosition = spawnPoints[randomIndex].transform.position;

        return randomPosition;
    }

    public void SpawnDroppables(Transform other)
    {
        int index = Random.Range(0, droppablesPrefab.Length);
        Instantiate(droppablesPrefab[index], other.position, other.rotation);
    }
}
