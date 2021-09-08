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
    public int heavyEnemies;
    public int standardEnemies;
    public int lightEnemies;
    ///public Transform[][] ActivePaths;
    ///
    public bool[] ActivePaths = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };




    private void Start()
    {
        actualLvl = -1;
        wp = FindObjectOfType<Waypoints>();
        heavyEnemies = 0;
        standardEnemies = 0;
        lightEnemies = 0;
        activatePaths();
    }
    public void startLvl()
    {
        switch (actualLvl)
        {
            case 0:
                ActivateSpawner(2);
                standardEnemies = 1;
                break;
            case 1:
                standardEnemies = 2;
                break;
            case 2:
                standardEnemies = 1;
                lightEnemies = 1;
                break;

            case 3:
                ClearRock(7);
                standardEnemies = 0;
                lightEnemies = 2;
                break;

            case 4:
                standardEnemies = 1;
                lightEnemies = 2;
                break;

            case 5:
                standardEnemies = 0;
                lightEnemies = 4;
                ClearRock(5);
                break;

            case 6:
                standardEnemies = 4;
                lightEnemies = 2;
                break;

            case 7:
                standardEnemies = 0;
                ActivateSpawner(1);
                lightEnemies = 5;       
                break;

            case 8:
                lightEnemies = 5;
                ClearRock(6);
                break;

            case 9:
                standardEnemies = 3;
                lightEnemies = 3;
                break;

            case 10:
                ClearRock(2);
                standardEnemies = 3;
                lightEnemies = 4;
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
}
