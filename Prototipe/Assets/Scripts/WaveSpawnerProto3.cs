using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WaveSpawnerProto3 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject HeavyEnemyPrefab;
    public GameObject LightEnemyPrefab;
    public UIManager lights;

    private Levels lvl;
    public float timeBetweenWaves;
    public int maxCantOfEnemiesPerWave;
    public bool waveIsInCourse;
    public int waveLimit;
    [SerializeField]
    private int waveCount = 0;
    public int enemyCount;

    private bool startWave;

    static public event Action winGameEvent;

    

    private void Start()
    {
        lights = FindObjectOfType<UIManager>();
        lvl = GetComponent<Levels>();
        WaveManager.StartWaveEvent += StartWaveCycle;
        Enemy.EnemyDie += DecreaseEnemyCount;
        FreeEnemy.EnemyDie += DecreaseEnemyCount;
        enemyCount = 0;
        startWave = false;
    }

    private void Update()
    {
        if (enemyCount <=0)
        {
            if (lights.LightsOnDayOff)
            lights.StartDay();
            lights.Lightoff();
        }
        if (waveCount >= waveLimit)
            winGameEvent?.Invoke();
        //Debug.Log("enemyCount: " + enemyCount);
        //Debug.Log("waves: " + waveCount);
    }

    void StartWaveCycle()
    {
        lvl.actualLvl++;
        lvl.startLvl();
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < lvl.standardEnemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        for (int i = 0; i < lvl.heavyEnemies; i++)
        {
            SpawnHeavyEnemy();
            yield return new WaitForSeconds(1.0f);
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
        int spawner = UnityEngine.Random.Range(0, lvl.activeSpawnStarts.Count);
        Debug.Log("llega");
        Instantiate(enemyPrefab, lvl.activeSpawnStarts[spawner].transform.localPosition, Quaternion.identity);
        Debug.Log("llega2");
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
