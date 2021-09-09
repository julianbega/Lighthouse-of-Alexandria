using UnityEngine;
using System;

public class Library : MonoBehaviour
{
    static public event Action OpenLibrary;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        OpenLibrary?.Invoke();
    }
}
