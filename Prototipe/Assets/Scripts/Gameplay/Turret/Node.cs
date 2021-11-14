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

    public GameManager gm;

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
        Node.ChangeAllNodesToStartColor += changeToStartColor;
        UIShop.changeActualNode += changeToStartColor;
        gm = FindObjectOfType<GameManager>();
    }
    private void OnDisable()
    {
        UIManager.ChangeAllNodesToStartColor -= InvokeChangeToStartColor;
        Node.ChangeAllNodesToStartColor -= changeToStartColor;
        UIShop.changeActualNode -= changeToStartColor;

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
            changeToStartColor();
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

    private void changeToStartColor()
    {
        render.material = startColor;
    }


}
