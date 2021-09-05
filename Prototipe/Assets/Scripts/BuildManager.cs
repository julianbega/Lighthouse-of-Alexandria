using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public Node actualNode;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            return;
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
