﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WaveSpawnerProto3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject HeavyEnemyPrefab;
    public GameObject LightEnemyPrefab;

    private Levels lvl;
    public float timeBetweenWaves;
    public int maxCantOfEnemiesPerWave;
    public bool waveIsInCourse;
    public int enemyCount;
    private bool spawnsAreFinished;

    private UIManager uim;

    private void Start()
    {
        lvl = GetComponent<Levels>();
        uim = FindObjectOfType<UIManager>();
        WaveManager.StartWaveEvent += StartLvlCycle;
        Enemy.EnemyDie += DecreaseEnemyCount;
        FreeEnemy.EnemyDie += DecreaseEnemyCount;
        enemyCount = 0;
        spawnsAreFinished = true;
    }

    void StartLvlCycle()
    {
        if (enemyCount <= 0)
        {    
            lvl.ResetActualWave();
            lvl.IncreaseLVL();
            lvl.FindLvlInformation();
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        while (!lvl.CompareActualWaveAndTotalWavesAreEquals())
        {

            spawnsAreFinished = false;
            lvl.FindEnemiesSpawnInformation();
            for (int i = 0; i < lvl.GetStandardEnemies(); i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.75f);
            }
            for (int i = 0; i < lvl.GetHeavyEnemies(); i++)
            {
                SpawnHeavyEnemy();
                yield return new WaitForSeconds(1.0f);
            }
            for (int i = 0; i < lvl.GetLightEnemies(); i++)
            {
                SpawnLightEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            lvl.IncreaseActualWave();
            if(lvl.CompareActualWaveAndTotalWavesAreEquals())
            { spawnsAreFinished = true; }
            yield return new WaitForSeconds(lvl.GetTimeBetweenWaves());
        }
        
    }

    void SpawnEnemy()
    {
        enemyCount++;
        int spawner = UnityEngine.Random.Range(0, lvl.activeSpawnStarts.Count);
        Instantiate(enemyPrefab, lvl.activeSpawnStarts[spawner].transform.localPosition, Quaternion.identity);
    }
    void SpawnHeavyEnemy()
    {
        enemyCount++;
        int spawner = UnityEngine.Random.Range(0, lvl.activeSpawnStarts.Count);
        Instantiate(HeavyEnemyPrefab, lvl.activeSpawnStarts[spawner].transform.localPosition, Quaternion.identity);
    }
    void SpawnLightEnemy()
    {
        enemyCount++;
        int spawner = UnityEngine.Random.Range(0, lvl.activeSpawnStarts.Count);
        Instantiate(LightEnemyPrefab, lvl.activeSpawnStarts[spawner].transform.localPosition, Quaternion.identity);
    }

    void DecreaseEnemyCount()
    {
        enemyCount--;

        if (enemyCount <= 0 && spawnsAreFinished)
        {
            lvl.StartDay();
            uim.CanOpenShopTrue();
        }
    }


    private void OnDisable()
    {
        WaveManager.StartWaveEvent -= StartLvlCycle;
        Enemy.EnemyDie -= DecreaseEnemyCount;
        FreeEnemy.EnemyDie -= DecreaseEnemyCount;
    }

}
