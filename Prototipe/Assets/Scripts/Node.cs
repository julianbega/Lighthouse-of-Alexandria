using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color selectedColor;
    public Vector3 offset;
    private Color startColor;
    private Renderer render;
    public GameObject turret;

    public GameManager gm;

    public static event Action OpenShop;
    //public static event Action<int> GetMoney;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnMouseEnter()
    {
        render.material.color = selectedColor;
    }
    private void OnMouseExit()
    {
        render.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("not Buildable");
            return;
        }
        
        OpenShop?.Invoke();
        BuildManager.instance.actualNode = this;
        
        //GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        //if (gm.GetMoney() >= BuildManager.instance.turretPrice)
        //{
        //    turret = Instantiate(turretToBuild, transform.position + offset, transform.rotation);
        //    gm.moneySubtract(BuildManager.instance.turretPrice);
        //}
    }
}
