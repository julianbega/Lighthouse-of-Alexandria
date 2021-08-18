using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color selectedColor;
    private Color startColor;
    private Renderer render;

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
}
