using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WaveSpawnerProto3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject HeavyEnemyPrefab;
    public GameObject LightEnemyPrefab;
    private Transform[] spawnStarts;


    private Levels lvl;
    public float timeBetweenWaves;
    public int maxCantOfEnemiesPerWave;
    public bool waveIsInCourse;
    public int waveLimit;
    [SerializeField]
    private int waveCount = 0;
    public int enemyCount;

    private bool startWave;

    static public event Action winEvent;

    

    private void Start()
    {
        lvl = GetComponent<Levels>();
        WaveManager.StartWaveEvent += StartWaveCycle;
        Enemy.EnemyDie += DecreaseEnemyCount;
        FreeEnemy.EnemyDie += DecreaseEnemyCount;
        enemyCount = 0;
        startWave = false;
        spawnStarts = lvl.activeSpawnStarts;
    }

    private void Update()
    {
        if (startWave && enemyCount <= 0 && waveCount <= waveLimit)
        {
            StartCoroutine(SpawnWave());
        }
        if (waveCount >= waveLimit)
            winEvent?.Invoke();
        //Debug.Log("enemyCount: " + enemyCount);
        //Debug.Log("waves: " + waveCount);
    }

    void StartWaveCycle()
    {
        spawnStarts = lvl.activeSpawnStarts;
        startWave = true;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < lvl.standardEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }
        for (int i = 0; i < lvl.heavyEnemies; i++)
        {
            SpawnHeavyEnemy();
            yield return new WaitForSeconds(0.25f);
        }
        for (int i = 0; i < lvl.lightEnemies; i++)
        {
            SpawnLightEnemy();
            yield return new WaitForSeconds(0.25f);
        }

    }

    void SpawnEnemy()
    {
        enemyCount++;
        int spawner = UnityEngine.Random.Range(0, spawnStarts.Length);
        Instantiate(enemyPrefab, spawnStarts[spawner].transform.localPosition, Quaternion.identity);
    }
    void SpawnHeavyEnemy()
    {
        enemyCount++;
        int spawner = UnityEngine.Random.Range(0, spawnStarts.Length);
        Instantiate(HeavyEnemyPrefab, spawnStarts[spawner].transform.localPosition, Quaternion.identity);
    }
    void SpawnLightEnemy()
    {
        enemyCount++;
        int spawner = UnityEngine.Random.Range(0, spawnStarts.Length);
        Instantiate(LightEnemyPrefab, spawnStarts[spawner].transform.localPosition, Quaternion.identity);
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
