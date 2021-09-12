using UnityEngine;
using System;

public class UILibrary : MonoBehaviour
{
    private GameManager gm;
    public GameObject LibraryPanel;
    static public event Action UnlockTurretOneEvent;
    public Library library;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Library.OpenLibrary += ActivateLibraryPanel;
    }

    void Update()
    {
        
    }

    public void ActivateLibraryPanel()
    {
        LibraryPanel.gameObject.SetActive(true);
    }

    public void CloseLibraryPanel()
    {
        LibraryPanel.gameObject.SetActive(false);
    }

    public void UnlockTurret(int index)
    {
        library.turretUnlocked[index] = true;
    }

    private void OnDisable()
    {
        Library.OpenLibrary -= ActivateLibraryPanel;
    }
}
