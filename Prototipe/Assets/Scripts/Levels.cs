using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Levels : MonoBehaviour
{
    public GameObject[] rocks;
    public int actualLvl;
    public static Action ActivateLvlSpawners;
    public Transform[] activeSpawnStarts;
    public Transform[] allSpawners;
    public int heavyEnemies;
    public int standardEnemies;
    public int lightEnemies;

    private void Start()
    {
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
}
