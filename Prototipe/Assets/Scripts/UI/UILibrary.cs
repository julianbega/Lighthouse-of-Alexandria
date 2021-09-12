using UnityEngine;
using System;

public class UILibrary : MonoBehaviour
{
    private GameManager gm;
    public GameObject LibraryPanel;
    static public event Action UnlockTurretOneEvent;
    public Library library;
    public UIManager uiManager;
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
        uiManager.CanOpenShopFlase();
    }

    public void CloseLibraryPanel()
    {
        LibraryPanel.gameObject.SetActive(false);
        uiManager.CanOpenShopTrue();
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
