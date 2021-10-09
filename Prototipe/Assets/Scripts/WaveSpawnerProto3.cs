using System.Collections;
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
    public int enemyCount;
    private bool spawnsAreFinished;

    private UIManager uim;

    public static Action ShowNPC;
    static public event Action<string> SetStateDayAnim;

    private void Start()
    {
        lvl = GetComponent<Levels>();
        uim = FindObjectOfType<UIManager>();
        WaveManager.StartWaveEvent += StartLvlCycle;
        Enemy.EnemyDie += DecreaseEnemyCount;
        enemyCount = 0;
        spawnsAreFinished = true;
        SetStateDayAnim?.Invoke("Day");
    }

    void StartLvlCycle()
    {
        if (enemyCount <= 0)
        {
            /// arranca el ciclo dia noche, se hace de noche y despues pasa esto
            //SetStateDayAnim?.Invoke("Night");
            //Chequear con algun get de un bool si ya termino de girar y que ahi se haga todo esto
            if (!GameManager.GetInstance.finishNight && GameManager.instance.finishDay)
            {
                lvl.IncreaseLVL();
                Debug.Log("actualLvl: " + lvl.actualLvl);
                lvl.FindLvlInformation();
                StartCoroutine(SpawnWave());
            }
        }
    }

    IEnumerator SpawnWave()
    {

        Debug.Log("CompareActualWaveAndTotalWavesAreEquals: " + lvl.CompareActualWaveAndTotalWavesAreEquals());
        while (!lvl.CompareActualWaveAndTotalWavesAreEquals())
        {
            spawnsAreFinished = false;
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
            { 
                spawnsAreFinished = true;               
            }
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
            /// se hace de dia y cuando termina la animacion pasa esto
            lvl.StartDay();
            ShowNPC?.Invoke();
            uim.CanOpenShopTrue();
        }
    }


    private void OnDisable()
    {
        WaveManager.StartWaveEvent -= StartLvlCycle;
        Enemy.EnemyDie -= DecreaseEnemyCount;
    }

}
