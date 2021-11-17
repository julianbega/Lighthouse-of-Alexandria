using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConstructionManager : MonoBehaviour
{
    static public ConstructionManager instance;
    static public ConstructionManager GetInstance { get { return instance; } }
    public Node actualNode;
    public Turret selectedTurret;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            instance = this;
        }
    }

    public GameObject[] turretPrefabs;

    public GameObject GetTurretToBuild(int index)
    {
        return turretPrefabs[index];
    }
    public int GetTurretPrice(int index)
    {
        return turretPrefabs[index].GetComponent<Turret>().price;
    }
}
