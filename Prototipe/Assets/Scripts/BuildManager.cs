using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

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

    public GameObject turretPrefab;

    private void Start()
    {
        turret = turretPrefab;
    }
    private GameObject turret;

    public GameObject GetTurretToBuild()
    {
        return turret;
    }
}
