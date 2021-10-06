﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Levels : MonoBehaviour
{
    public List<LevelDataSO> levels;
    public LevelDataSO actualLevelDataSO;

    public GameObject[] rocks;
    public int actualLvl;
    public static Action ActivateLvlSpawners;
    public List<Transform> activeSpawnStarts;
    public Transform[] allSpawners;
    public static Action SetDayOn;
    public static Action SetNightOn;  
    public static Action<int, string> ShowNPCs;
    private bool itIsDay;
    [SerializeField] private Animator dayCycle;

    private void Start()
    {
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].actualWave = 0;
        }
        WaveSpawnerProto3.ShowNPC += InvokeNPCShow;
    }
    private void OnDisable()
    {
        WaveSpawnerProto3.ShowNPC -= InvokeNPCShow;
    }
    public void FindLvlInformation()  /// setea cantidad de waves, habilita spawners o limpia piedras
    {
        StartNight();
        //dayCycle.SetBool("isDay", actualLevelDataSO.ItIsDay);
        if (actualLevelDataSO.ItIsDay)
        {
            StartDay();
            Debug.Log("Es de dia xd");
            //dayCycle.SetBool("isDay", actualLevelDataSO.ItIsDay);
        }
        ActivateSpawner(actualLevelDataSO.activateSpawner);
        ClearRock(actualLevelDataSO.clearRock);        
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
            rocks[Index-1].SetActive(false);
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
        itIsDay = true;
        SetDayOn?.Invoke();
    }
    public void StartNight()
    {
        itIsDay = false;
        SetNightOn?.Invoke();
    }
    public void InvokeNPCShow()
    {
        ShowNPCs?.Invoke(actualLevelDataSO.NPCToTalk, actualLevelDataSO.Dialog);
    }
    public bool askIfDay()
    {
        return itIsDay;
    }
}
