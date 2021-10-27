using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Levels : MonoBehaviour
{
    public List<LevelDataSO> levels;
    public LevelDataSO actualLevelDataSO;

    public GameObject[] rocks;
    public GameObject[] WaterPaths;
    public int actualLvl;
    public static Action ActivateLvlSpawners;
    public List<Transform> activeSpawnStarts;
    public Transform[] allSpawners;
    public static Action<string> SetDayOn;
    public static Action<string> SetNightOn;  
    public static Action<NPC_SO, string> ShowNPCs;


    private void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].actualWave = 0;
        }
        WaveSpawner.ShowNPC += InvokeNPCShow;
    }
    private void OnDisable()
    {
        WaveSpawner.ShowNPC -= InvokeNPCShow;
    }
    public void FindLvlInformation()  /// setea cantidad de waves, habilita spawners o limpia piedras
    {
        if(GameManager.instance.finishDay)
            StartNight();
        if (actualLevelDataSO.ItIsDay && GameManager.instance.finishNight)
        {
            StartDay();
        }
        ActivateSpawner(actualLevelDataSO.activateSpawner);
        ClearRock(actualLevelDataSO.clearRock);
        ActivatePath(actualLevelDataSO.activateWater);
    }
    
    private void ActivateSpawner(int Index)
    {
        if (Index != -1)
        { 
        allSpawners[Index].gameObject.SetActive(true);       
        activeSpawnStarts.Add (allSpawners[Index]);
        }
    }

    private void ClearRock(int Index)
    {
        if (Index != -1)
        {
            rocks[Index - 1].SetActive(false);
        }
    }
    private void ActivatePath(int Index)
    {
        if (Index != -1)
        {
            WaterPaths[Index - 1].SetActive(true);
        }
    }

    public int GetStandardEnemies()
    {
        return actualLevelDataSO.waves[actualLevelDataSO.actualWave].standardEnemies;
    }
    public int GetLightEnemies()
    {
        return actualLevelDataSO.waves[actualLevelDataSO.actualWave].lightEnemies;
    }
    public int GetHeavyEnemies()
    {
        return actualLevelDataSO.waves[actualLevelDataSO.actualWave].heavyEnemies;
    }
    public int GetActualLVL()
    {
        return actualLvl;
    }
    public void IncreaseLVL()
    {
        if (actualLevelDataSO != null)
        { 
            actualLvl++;
            actualLevelDataSO = levels[actualLvl];
        }
    }
    public int GetActualWave()
    {
        if (actualLevelDataSO != null)
        { 
        return actualLevelDataSO.actualWave;
        }
        return 0;
    }
    public void IncreaseActualWave()
    {
        actualLevelDataSO.actualWave++;
    }  
    public int GetTotalWaves()
    {
        return actualLevelDataSO.waves.Count;
    }
    public bool CompareActualWaveAndTotalWavesAreEquals()
    {
        return ((GetTotalWaves() == GetActualWave()));
    }
    public float GetTimeBetweenWaves()
    {
        return actualLevelDataSO.waves[actualLevelDataSO.actualWave].timeBetweenWaves;
    }
    public void StartDay()
    {
        Debug.Log("start day");
        //Con este evento llamar a la funcion del gamemanager que controla los ciclos
        
            Debug.Log("StartDay2");
            SetDayOn?.Invoke("Day");
    }
    public void StartNight()
    {
        //Con este evento llamar a la funcion del gamemanager que controla los ciclos
        if (!actualLevelDataSO.ItIsDay)
        {
            SetNightOn?.Invoke("Night");
        }
    }
    public void InvokeNPCShow()
    {
        ShowNPCs?.Invoke(actualLevelDataSO.NPCToTalk, actualLevelDataSO.Dialog);
    }
    public bool askIfDay()
    {
        return actualLevelDataSO.ItIsDay;
    }
}
