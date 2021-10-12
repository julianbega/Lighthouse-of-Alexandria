using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Material onMouseColor;
    public Vector3 offset;
    public Material startColor;
    public Material selectedColor;
    private Renderer render;
    public GameObject turret;

    public GameManager gm;

    public static event Action OpenShop;
    public static event Action ChangeAllNodesToStartColor;
    //public static event Action<int> GetMoney;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.material = startColor;
    }
    private void Start()
    {
        UIManager.ChangeAllNodesToStartColor += InvokeChangeToStartColor;
        Node.ChangeAllNodesToStartColor += changeToStartColor;
        UIShop.changeActualNode += changeToStartColor;
        UIUpgradeSystem.changeActualNode += changeToStartColor;
        gm = FindObjectOfType<GameManager>();
    }
    private void OnDisable()
    {
        UIManager.ChangeAllNodesToStartColor -= InvokeChangeToStartColor;
        Node.ChangeAllNodesToStartColor -= changeToStartColor;
        UIShop.changeActualNode -= changeToStartColor;
        UIUpgradeSystem.changeActualNode -= changeToStartColor;

    }
    private void OnMouseEnter()
    {

        if (BuildManager.instance.actualNode != this)
        {
            render.material = onMouseColor;
        }
    }
    private void OnMouseExit()
    {
        if (BuildManager.instance.actualNode != this)
        {
            changeToStartColor();
        }
    }

    private void OnMouseDown()
    {
       
    }

    private void OnMouseUp()
    {
        if (turret != null)
        {
            Debug.Log("not Buildable");
            return;
        }
        ChangeAllNodesToStartColor?.Invoke();
        render.material = selectedColor;
        OpenShop?.Invoke();
        BuildManager.instance.actualNode = this;

    }

    private void InvokeChangeToStartColor()
    {
        ChangeAllNodesToStartColor?.Invoke();
    }

    private void changeToStartColor()
    {
        render.material = startColor;
    }


}
