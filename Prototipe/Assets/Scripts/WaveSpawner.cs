using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnStart;

    public float timeBetweenWaves;
    public bool waveIsInCourse;
    private float timerContdown = 2.0f;
    private int waveCount = 0;

    private void Update()
    {
        if (timerContdown <= 0)
        {
            StartCoroutine(SpawnWave());
            timerContdown = timeBetweenWaves;
        }
        timerContdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveCount++;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }

    }

    void SpawnEnemy() 
    {
        Instantiate(enemyPrefab, spawnStart, true);
    }
    
}
