using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Levels : MonoBehaviour
{
    public GameObject[] rocks;
    private Waypoints wp;
    private bool[] activeSpawners = { false, false, false, false, false };
    private bool[] activeRocks = { true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
    public int actualLvl;
    public static Action ActivateLvlSpawners;
    public List<Transform> activeSpawnStarts;
    public Transform[] allSpawners;
    [SerializeField]private int heavyEnemies;
    [SerializeField] private int standardEnemies;
    [SerializeField] private int lightEnemies;

    public bool itIsDay;
    public static Action SetDayOn;
    public static Action SetNightOn;
    private int totalWaves;
    private int actualWave;
    private float timeBetweenWaves;
    public bool[] ActivePaths = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    public static Action<int, string> ShowNPCs;
    private int NPCToTalk;
    private string Dialog;


    private void Start()
    {
        WaveSpawnerProto3.ShowNPC += InvokeNPCShow;
        actualLvl = -1;
        wp = FindObjectOfType<Waypoints>();
        heavyEnemies = 0;
        standardEnemies = 0;
        lightEnemies = 0;
        activatePaths();
    }
    private void OnDisable()
    {
        WaveSpawnerProto3.ShowNPC -= InvokeNPCShow;
    }
    public void FindLvlInformation()  /// setea cantidad de waves, habilita spawners o limpia piedras
    {
        StartNight();
        switch (actualLvl)
        {
            case 0:
                StartDay();
                ActivateSpawner(2);
                totalWaves = 2;
                timeBetweenWaves = 4f;
                NPCToTalk = 1;
                Dialog = "Nos van a venir de noche, usá el faro para iluminar a los enemigos y que nuestras torres puedan atacarlos";
                break;
            case 1:
                NPCToTalk = 0;
                Dialog = "";
                break;
            case 2:

                NPCToTalk = 2;
                Dialog = "Una piedra está por colapsar";
                break;

            case 3:
                NPCToTalk = 0;
                Dialog = "";
                ClearRock(7);
                /// npc dice que van a venir barcos más rapidos
                break;

            case 4:
                /// Introducir Barco rapido
                break;

            case 5:
                ClearRock(6);
                break;

            case 6:
                NPCToTalk = 3;
                Dialog = "Va a venir otra flota de barcos";
            
                break;

            case 7:
                ClearRock(5);
                NPCToTalk = 0;
                Dialog = "";
                ActivateSpawner(1);
                break;

            case 8:
                // Biblioteca
                break;

            case 9:
                ClearRock(8);
                // npc que diga que los enemigos parecen estar reagrupandose
                break;

            case 10:
                // Nivel de descanzo (vienen menos enemigos)
                break;
            case 11:
                // Nivel de descanzo (vienen menos enemigos)
                break;
            case 12:
                ClearRock(2);
                break;
            case 13:
                break;
            case 14:
                /// Desbloqueo de nueva rama de la biblioteca  // charla con npc
                break;
            case 15:

                break;
            case 16:
                ClearRock(3);
                break;
  
        }
    }
    public void FindEnemiesSpawnInformation() /// setea cuantos y cuales enemigos va a haber en cada wave en cada lvl
    {
        switch (actualLvl)
        {
            case 0: 
                switch (actualWave)
                {
                    case 0:
                        standardEnemies = 1;
                        break;
                    case 1:
                        standardEnemies = 1;
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                switch (actualWave)
                {
                    case 0:
                        standardEnemies = 2;
                        break;
                    case 1:
                        standardEnemies = 1;
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (actualWave)
                {
                    case 0:
                        standardEnemies = 1;
                        lightEnemies = 1;
                        break;
                    case 1:
                        standardEnemies = 1;
                        break;
                    default:
                        break;
                }
                break;

            case 3:
                switch (actualWave)
                {
                    case 0:
                        standardEnemies = 2;
                        lightEnemies = 0;
                        break;
                    case 1:
                        standardEnemies = 0;
                        lightEnemies = 2;
                        break;
                    default:
                        break;
                }
                break;

            case 4:
                switch (actualWave)
                {
                    case 0:
                        standardEnemies = 1;
                        lightEnemies = 1;
                        break;
                    case 1:
                        standardEnemies = 1;
                        lightEnemies = 1;
                        break;
                    default:
                        break;
                }
                break;

            case 5:
                switch (actualWave)
                {
                    case 0:
                        standardEnemies = 1;
                        lightEnemies = 1;
                        break;
                    case 1:
                        standardEnemies = 1;
                        lightEnemies = 2;
                        break;
                    default:
                        break;
                }
                break;

            case 6:
                switch (actualWave)
                {
                    case 0:
                        standardEnemies = 1;
                        lightEnemies = 2;
                        break;
                    case 1:
                        standardEnemies = 1;
                        lightEnemies = 2;
                        break;
                    default:
                        break;
                }
                break;

            case 7:
                switch (actualWave)
                {
                    case 0:
                        heavyEnemies = 1;
                        standardEnemies = 1;
                        lightEnemies = 0;
                        break;
                    case 1:
                        heavyEnemies = 0;
                        standardEnemies = 0;
                        lightEnemies = 3;
                        break;
                    default:
                        break;
                }
                break;

            case 8:
                switch (actualWave)
                {
                    case 0:
                        heavyEnemies = 0;
                        standardEnemies = 1;
                        lightEnemies = 3;
                        break;
                    case 1:
                        standardEnemies = 2;
                        lightEnemies = 2;
                        break;
                    default:
                        break;
                }
                break;

            case 9:
                break;

            case 10:
                break;
            default:
                break;
        }
    }

    private void ActivateSpawner(int Index)
    {
        activeSpawners[Index] = true;
        allSpawners[Index].gameObject.SetActive(true);
        //---------------------------------------------------//
       
        activeSpawnStarts.Add (allSpawners[Index]);
        activatePaths();
    }

    private void ClearRock(int Index)
    {
        activeRocks[Index-1] = false;
        rocks[Index-1].SetActive(false);
        activatePaths();
    }

    public void activatePaths()
    {        
        if (activeSpawners[0] == true)
        {
            if (activeRocks[0] == false)
            {
                ActivePaths[0] = true;
                ActivePaths[1] = true;
                ActivePaths[4] = true;
                if (activeRocks[3] == false)
                {
                    ActivePaths[2] = true;
                    ActivePaths[3] = true;
                }
            }
            
        }
        if (activeSpawners[1] == true)
        {
            if (activeRocks[1] == false)
            {
                ActivePaths[7] = true;
                if (activeRocks[2] == false)
                {
                    ActivePaths[5] = true;
                    if (activeRocks[3] == false)
                    {
                        ActivePaths[6] = true;
                    }
                }
            }

            if (activeRocks[4] == false)
            {
                ActivePaths[12] = true;
                //Path13 va
                if (activeRocks[5] == false)
                {
                    ActivePaths[8] = true;
                    //Path9 va
                    if (activeRocks[2] == false)
                    {
                        ActivePaths[10] = true;
                        //Path11 va
                        if (activeRocks[3] == false)
                        {
                            ActivePaths[9] = true;
                            //Path10 va
                        }
                    }
                }
                if (activeRocks[6] == false)
                {
                    ActivePaths[11] = true;
                    //Path12 va
                }
                if (activeRocks[7] == false)
                {
                    ActivePaths[13] = true;
                    //Path14 va
                    if (activeRocks[11] == false)
                    {
                        ActivePaths[14] = true;
                        //Path15 va
                    }
                }
            }

        }
        if (activeSpawners[2] == true)
        {
            ActivePaths[19] = true;
            /// path 20 va
            if (activeRocks[5] == false)
            {
                ActivePaths[15] = true;
                /// path 16 va
                if (activeRocks[2] == false)
                {
                    ActivePaths[17] = true;
                    /// path 18 va
                    if (activeRocks[3] == false)
                    {
                        ActivePaths[16] = true;
                        /// path 17 va
                    }
                }
            }
            if (activeRocks[6] == false)
            {
                ActivePaths[18] = true;
                /// path 19 va
            }
            if (activeRocks[7] == false)
            {
                ActivePaths[20] = true;
                /// path 21 va
                if (activeRocks[11] == false)
                {
                    ActivePaths[21] = true;
                    /// path 22 va
                }
            }
        }
        if (activeSpawners[3] == true)
        {
            if (activeRocks[8] == false)
            {
                ActivePaths[22] = true;
                //Path23 va
                if (activeRocks[11] == false)
                {
                    ActivePaths[23] = true;
                    //Path24 va
                }
                if (activeRocks[9] == false)
                {
                    ActivePaths[25] = true;
                    //Path26 va
                    if (activeRocks[10] == false)
                    {
                        ActivePaths[24] = true;
                        ActivePaths[26] = true;
                        //Path25 va
                        //Path27 va
                    }
                    if (activeRocks[11] == false)
                    {
                        ActivePaths[27] = true;
                        //Path28 va
                    }
                    if (activeRocks[13] == false)
                    {
                        ActivePaths[28] = true;
                        //Path29 va
                    }
                }
            }
            if (activeRocks[12] == false)
            {
                ActivePaths[30] = true;
                //Path31 va
                if (activeRocks[10] == false)
                {
                    ActivePaths[29] = true;
                    //Path30 va
                    if (activeRocks[11] == false)
                    {
                        ActivePaths[31] = true;
                        //Path32 va
                    }
                }
                if (activeRocks[11] == false)
                {
                    ActivePaths[32] = true;
                    //Path33 va
                }
                if (activeRocks[13] == false)
                {
                    ActivePaths[33] = true;
                    //Path34 va
                }
            }
            if (activeRocks[14] == false)
            {
                ActivePaths[36] = true;
                //Path37 va
                if (activeRocks[13] == false)
                {
                    ActivePaths[34] = true;
                    //Path35 va
                    if (activeRocks[11] == false)
                    {
                        ActivePaths[35] = true;
                        //Path36 va
                    }
                }
            }

        }
        if (activeSpawners[4] == true)
        {
            if (activeRocks[15] == false && activeRocks[14] == false)
            {
                ActivePaths[39] = true;
                //Path40 va
                if (activeRocks[13] == false)
                {
                    ActivePaths[37] = true;
                    //Path38 va
                    if (activeRocks[11] == false)
                    {
                        ActivePaths[38] = true;
                        //Path39 va
                    }
                }
            }

        }
    }


    public int GetStandardEnemies()
    {
        return standardEnemies;
    }
    public int GetLightEnemies()
    {
        return lightEnemies;
    }
    public int GetHeavyEnemies()
    {
        return heavyEnemies;
    }
    public int GetActualLVL()
    {
        return actualLvl;
    }
    public void IncreaseLVL()
    {
        actualLvl++;
    }
    public int GetActualWave()
    {
        return actualWave;
    }
    public void IncreaseActualWave()
    {
        actualWave++;
    }
    public void ResetActualWave()
    {
        actualWave = 0;
    }
    public int GetTotalWaves()
    {
        return totalWaves;
    }
    public bool CompareActualWaveAndTotalWavesAreEquals()
    {
        return ((totalWaves == actualWave));
    }
    public float GetTimeBetweenWaves()
    {
        return timeBetweenWaves;
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
        Debug.Log("Llama al invoke 2");
        ShowNPCs?.Invoke(NPCToTalk,Dialog);
    }
}
