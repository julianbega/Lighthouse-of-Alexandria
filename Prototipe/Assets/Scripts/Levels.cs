using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Levels : MonoBehaviour
{
    public GameObject[] rocks;
    private Waypoints wp;
    private bool[] activeRocks = { true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
    public int actualLvl;
    public static Action ActivateLvlSpawners;
    public Transform[] activeSpawnStarts;
    public Transform[] allSpawners;
    public int heavyEnemies;
    public int standardEnemies;
    public int lightEnemies;

    private void Start()
    {        
        wp = FindObjectOfType<Waypoints>();
        heavyEnemies = 0;
        standardEnemies = 0;
        lightEnemies = 0;
    }
    public void startLvl()
    {
        switch (actualLvl)
        {
            case 0:
                ActivateSpawner(2);
                ClearRock(6);
                heavyEnemies = 0;
                standardEnemies = 1;
                lightEnemies = 0;
                break;
            case 1:
                heavyEnemies = 0;
                standardEnemies = 2;
                lightEnemies = 0;
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6:
                break;

            case 7:
                ActivateSpawner(1);
                break;

            case 8:
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
        allSpawners[Index].gameObject.SetActive(true);
        Debug.Log(activeSpawnStarts.Length);
        Transform[] aux = activeSpawnStarts;
        activeSpawnStarts = new Transform[activeSpawnStarts.Length + 1];
        activeSpawnStarts[activeSpawnStarts.Length - 1] = allSpawners[Index];
        for (int i = 0; i < aux.Length; i++)
        {
            Debug.Log(activeSpawnStarts[i]);
            activeSpawnStarts[i] = aux[i];
        }
            //+= allSpawners[Index];
    }

    private void ClearRock(int Index)
    {
        activeRocks[Index-1] = false;
        rocks[Index-1].SetActive(false);
    }
}
