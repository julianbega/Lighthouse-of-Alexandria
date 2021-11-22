using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Material onMouseColor;
    public Vector3 offset;
    public Material startColor;
    public Material selectedColor;
    private Renderer render;
    public GameObject turret;

    public static event Action<int> OpenShop;
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
        Node.ChangeAllNodesToStartColor += ChangeToStartColor;
        UIShop.changeActualNode += ChangeToStartColor;
    }
    private void OnDisable()
    {
        UIManager.ChangeAllNodesToStartColor -= InvokeChangeToStartColor;
        Node.ChangeAllNodesToStartColor -= ChangeToStartColor;
        UIShop.changeActualNode -= ChangeToStartColor;

    }
    private void OnMouseEnter()
    {

        if (ConstructionManager.instance.actualNode != this)
        {
            render.material = onMouseColor;
        }
    }
    private void OnMouseExit()
    {
        if (ConstructionManager.instance.actualNode != this)
        {
            ChangeToStartColor();
        }
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            OpenShop?.Invoke(0);
            ConstructionManager.instance.actualNode = this;
        }
    }

    private void InvokeChangeToStartColor()
    {
        ChangeAllNodesToStartColor?.Invoke();
    }

    private void ChangeToStartColor()
    {
        render.material = startColor;
    }


}
