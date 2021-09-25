using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Material onMouseColor;
    public Vector3 offset;
    public Material startColor;
    private Renderer render;
    public GameObject turret;

    public GameManager gm;

    public static event Action OpenShop;
    //public static event Action<int> GetMoney;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.material = startColor;
    }
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnMouseEnter()
    {
        render.material = onMouseColor;
    }
    private void OnMouseExit()
    {
        render.material = startColor;
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
        
    }
}
