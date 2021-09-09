using UnityEngine;
using System;

public class UILibrary : MonoBehaviour
{
    private GameManager gm;
    public Turret turret;

    public GameObject LibraryPanel;

    //static public event Action UnlockTurretOneEvent;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        turret = FindObjectOfType<Turret>();
        Library.OpenLibrary += ActivateLibraryPanel;
    }

    void Update()
    {
        
    }

    public void ActivateLibraryPanel()
    {
        LibraryPanel.SetActive(true);
    }

    public void CloseLibraryPanel()
    {
        LibraryPanel.SetActive(false);
    }

    private void OnDisable()
    {
        Library.OpenLibrary -= ActivateLibraryPanel;
    }
}
