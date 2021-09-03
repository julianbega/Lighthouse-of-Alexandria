using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WaveSpawnerProto3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject HeavyEnemyPrefab;
    public GameObject FastEnemyPrefab;
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
                        SpawnEnemy(false,false,true,false,false);
                        enemyCount++;
                        yield return new WaitForSeconds(0.25f);
                    }
                }
                waveCount++;
                break;
        }
        
    }

    void SpawnEnemy(bool spawner1, bool spawner2, bool spawner3, bool spawner4, bool spawner5)
    {
        if (spawner1)
        {
            activeSpawnStarts[activeSpawnStarts.Length+1] = spawnStarts[0];
        }
        int spawner = UnityEngine.Random.Range(0, spawnStarts.Length);
        //Debug.Log("spawn: " + spawnStart[spawner].position);
        Instantiate(enemyPrefab, spawnStarts[spawner].transform.localPosition, Quaternion.identity);
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
