using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WaveSpawnerProto3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject HeavyEnemyPrefab;
    public GameObject LightEnemyPrefab;
    public Transform[] spawnStarts;
    private Transform[] activeSpawnStarts;

    private Levels lvl;
    public float timeBetweenWaves;
    public int maxCantOfEnemiesPerWave;
    public bool waveIsInCourse;
    private float timerContdown = 2.0f;
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
        startWave = true;
    }

    IEnumerator SpawnWave()
    {
        switch (lvl.actualLvl)
        {
            case 1:
                break;
           
            
            
            default:
                for (int i = 0; i < maxCantOfEnemiesPerWave; i++)
                {
                    if (enemyCount < maxCantOfEnemiesPerWave) //maximo 7 oleadas
                    {
                        SpawnEnemy(spawnStarts[0]);
                        SpawnEnemy(spawnStarts[1]);
                        SpawnEnemy(spawnStarts[2]); 
                        SpawnEnemy(spawnStarts[3]);
                        SpawnEnemy(spawnStarts[4]);
                        enemyCount++;
                        yield return new WaitForSeconds(0.25f);
                    }
                }
                waveCount++;
                break;
        }
        
    }

    void SpawnEnemy(Transform spawner)
    {
        Instantiate(enemyPrefab, spawner.transform.localPosition, Quaternion.identity);
    }
    void SpawnHeavyEnemy(Transform spawner)
    {
        Instantiate(HeavyEnemyPrefab, spawner.transform.localPosition, Quaternion.identity);
    }
    void SpawnLightEnemy(Transform spawner)
    {
        Instantiate(LightEnemyPrefab, spawner.transform.localPosition, Quaternion.identity);
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
