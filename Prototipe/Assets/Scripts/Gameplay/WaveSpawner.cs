using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveSpawner : MonoBehaviour
{
    private Levels lvl;
    public int enemyCount;
    private bool spawnsAreFinished;
    
    public static Action ShowNPC;
    static public event Action<string> SetStateDayAnim;

    private void Start()
    {
        lvl = GetComponent<Levels>();
        WaveManager.StartWaveEvent += StartLvlCycle;
        Enemy.EnemyDie += DecreaseEnemyCount;
        enemyCount = 0;
        spawnsAreFinished = true;
        SetStateDayAnim?.Invoke("Day");
        
    }   

    void StartLvlCycle()
    {
     //   StartCoroutine(CheckEnemies());
        if (enemyCount <= 0)
        {
            /// arranca el ciclo dia noche, se hace de noche y despues pasa esto
            //SetStateDayAnim?.Invoke("Night");
            //Chequear con algun get de un bool si ya termino de girar y que ahi se haga todo esto
            if ((!GameManager.GetInstance.finishNight && GameManager.instance.finishDay) || (lvl.actualLvl == -1))
            {
                lvl.IncreaseLVL();
                lvl.FindLvlInformation();
                StartCoroutine(SpawnWave());
            }
        }
    }

   
    IEnumerator SpawnWave()
    {
        while (!lvl.CompareActualWaveAndTotalWavesAreEquals())
        {
            spawnsAreFinished = false;
            for (int i = 0; i < lvl.GetQuantityOfEnemieTypesInThisWave(); i++)
            {
                int actualWave = lvl.actualLevelDataSO.actualWave;
                for (int j = 0; j < lvl.actualLevelDataSO.waves[actualWave].Enemies[i].quantity; j++)
                {
                   SpawnEnemy(lvl.actualLevelDataSO.waves[actualWave].Enemies[i].type.prefab);
                    yield return new WaitForSeconds(1.0f);
                }

                yield return new WaitForSeconds(0.75f);
            }
            lvl.IncreaseActualWave();
            if (lvl.CompareActualWaveAndTotalWavesAreEquals())
            {
                spawnsAreFinished = true;
            }
            yield return new WaitForSeconds(lvl.GetTimeBetweenWaves());
        }
    }

    /*IEnumerator CheckEnemies()
    {
        Debug.Log("check enemies");
        GameObject[] missingEnemies;
        while (enemyCount > 0)
        {
            missingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log("enemies alive " + missingEnemies.Length);
            if (missingEnemies.Length <= 0)
            {
                enemyCount = 0;
                lvl.StartDay();
                ShowNPC?.Invoke();
                StopCoroutine(CheckEnemies());
            }
            yield return new WaitForSeconds(5f);
        }
        
    }*/
    void SpawnEnemy(GameObject enemyPrefab)
    {
        enemyCount++;
        int spawner = UnityEngine.Random.Range(0, lvl.activeSpawnStarts.Count);
        Instantiate(enemyPrefab, lvl.activeSpawnStarts[spawner].transform.localPosition, Quaternion.identity);
    }


    void DecreaseEnemyCount()
    {
        enemyCount--;

        if (enemyCount <= 0 && spawnsAreFinished)
        {
            Enemy[] missingEnemies = FindObjectsOfType<Enemy>();
            if (missingEnemies.Length <= 1)
            { 
            lvl.StartDay();
            ShowNPC?.Invoke();
           // StopCoroutine(CheckEnemies());
            }
            else 
            {
                enemyCount = missingEnemies.Length;
            }
        }
    }


    private void OnDisable()
    {
        WaveManager.StartWaveEvent -= StartLvlCycle;
        Enemy.EnemyDie -= DecreaseEnemyCount;
    }
}
