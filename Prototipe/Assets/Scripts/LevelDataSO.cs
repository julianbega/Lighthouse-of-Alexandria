using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public bool ItIsDay;
    public int activateSpawner = -1;
    public int clearRock = -1;
    public int activateWater = -1;
    public int NPCToTalk = 0;
    public string Dialog = "";
    public List<WaveData> waves;
    public int actualWave = 0;

    [Serializable]
    public class WaveData
    {
        public int heavyEnemies;
        public int standardEnemies;
        public int lightEnemies;
        public float timeBetweenWaves = 4f;
    }

    
}