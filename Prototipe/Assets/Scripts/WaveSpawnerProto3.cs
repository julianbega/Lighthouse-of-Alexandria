﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerProto3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnStart;

    public float timeBetweenWaves;
    public int maxCantOfEnemiesPerWave;
    public bool waveIsInCourse;
    private float timerContdown = 2.0f;
    private int waveCount = 0;
    private int enemyCount;

    private bool startWave;

    private void Start()
    {
       
        WaveManager.StartWaveEvent += StartWaveCycle;
        Enemy.EnemyDie += DecreaseEnemyCount;
        FreeEnemy.EnemyDie += DecreaseEnemyCount;
        enemyCount = 0;
        startWave = false;
    }

    private void Update()
    {
        if (startWave && enemyCount <= 0 && waveCount <= 7)
        {
            StartCoroutine(SpawnWave());
        }
        Debug.Log("enemyCount: " + enemyCount);
        Debug.Log("waves: " + waveCount);
    }

    void StartWaveCycle()
    {
        startWave = true;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < maxCantOfEnemiesPerWave; i++)
        {
            if (enemyCount < maxCantOfEnemiesPerWave) //maximo 7 oleadas
            {
                SpawnEnemy();
                enemyCount++;
                yield return new WaitForSeconds(0.25f);
            }
        }
        waveCount++;
    }

    void SpawnEnemy()
    {
        int spawner = Random.Range(0, spawnStart.Length);
        Debug.Log("spawn: " + spawnStart[spawner].position);
        Instantiate(enemyPrefab, spawnStart[spawner].transform.localPosition, Quaternion.identity);
    }

    void DecreaseEnemyCount()
    {
        if (enemyCount >= 0)
            enemyCount--;
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    private void OnDisable()
    {
        WaveManager.StartWaveEvent -= StartWaveCycle;
        Enemy.EnemyDie -= DecreaseEnemyCount;
        FreeEnemy.EnemyDie -= DecreaseEnemyCount;
    }
}