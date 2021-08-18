using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color selectedColor;
    public Vector3 offset;
    private Color startColor;
    private Renderer render;
    private GameObject turret;
    private void Awake()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
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
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + offset, transform.rotation);
    }
}
