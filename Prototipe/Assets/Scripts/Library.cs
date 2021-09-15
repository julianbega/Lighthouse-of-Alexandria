using UnityEngine;
using System;
using System.Collections.Generic;

public class Library : MonoBehaviour
{
    static public event Action OpenLibrary;
    public List<bool> turretUnlocked = new List<bool>();
    private int cantTypeturret;
    void Start()
    {
        cantTypeturret = 4;
        turretUnlocked[0] = true;
        for (int i = 1; i < cantTypeturret; i++)
        {
            turretUnlocked[i] = false;
        }
    }

    private void OnMouseDown()
    {
        OpenLibrary?.Invoke();
    }
}
