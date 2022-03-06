using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveSpawner : MonoBehaviour
{
    private LevelManager lvl;
    private bool spawnsAreFinished;
    private bool isCombat;
    public List<GameObject> enemiesAlive;
    public static Action ShowNPC;
    static public event Action<string> SetStateDayAnim;
    private const int startIndexOfLevel = -1;

    private uint waveSpawnerMusicID;

    private void Start()
    {
        lvl = GetComponent<LevelManager>();
        WaveManager.StartWaveEvent += StartLvlCycle;
        Enemy.EnemyDie += DecreaseEnemyCount;
        spawnsAreFinished = true;
        SetStateDayAnim?.Invoke("Day");
        isCombat = false;
        InvokeRepeating("CheckEndLevel", 0f, 0.5f);
    }

    void StartLvlCycle()
    {
     //   StartCoroutine(CheckEnemies());
        if (enemiesAlive.Count <= 0 )
        {
            /// arranca el ciclo dia noche, se hace de noche y despues pasa esto
            //SetStateDayAnim?.Invoke("Night");
            //Chequear con algun get de un bool si ya termino de girar y que ahi se haga todo esto
            if ((!GameManager.GetInstance.finishNight && GameManager.instance.finishDay) || (lvl.actualLvl == startIndexOfLevel))
            {
                ConstructionManager.instance.buildAvailable = false;                
                    isCombat = true;
                lvl.IncreaseLVL();
                lvl.FindLvlInformation();
                StartCoroutine(SpawnWave());
                waveSpawnerMusicID = AkSoundEngine.PostEvent("level_warhorn", this.gameObject);
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
                ConstructionManager.instance.buildAvailable = true;
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
        int spawner = UnityEngine.Random.Range(0, lvl.activeSpawnStarts.Count);
        GameObject newGO = (GameObject)Instantiate(enemyPrefab, lvl.activeSpawnStarts[spawner].transform.position, Quaternion.identity);
        enemiesAlive.Add(newGO); 
    }


    void DecreaseEnemyCount()
    {
        for (int i = 0; i < enemiesAlive.Count; i++)
        {
            Enemy enemieToCheck = enemiesAlive[i].GetComponent<Enemy>();
            if(enemieToCheck.life <= 0 || enemiesAlive[i] == null)
            {
                enemiesAlive.RemoveAt(i);                
            }
        }
    }

    void CheckEndLevel()
    {
        if (enemiesAlive.Count <= 0 && spawnsAreFinished && isCombat)
        {
            lvl.StartDay();
            ShowNPC?.Invoke();
            isCombat = false;
        }
    }

    public void StopMusic()
    {
        AkSoundEngine.StopPlayingID(waveSpawnerMusicID);
    }

    private void OnDisable()
    {
        WaveManager.StartWaveEvent -= StartLvlCycle;
        Enemy.EnemyDie -= DecreaseEnemyCount;
        StopMusic();
    }
}
