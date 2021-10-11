using UnityEngine;
using System;

public class UILibrary : MonoBehaviour
{
    private GameManager gm;
    public GameObject LibraryPanel;
    public Library library;
    public UIManager uiManager;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Library.OpenLibrary += ActivateLibraryPanel;
    }

    public void ActivateLibraryPanel()
    {
        if(uiManager.canOpenLibrary)
            LibraryPanel.gameObject.SetActive(true);
        uiManager.CanOpenShopFalse();
        uiManager.CanOpenUpgradeSystemFalse();
        uiManager.HidePauseBtn();
        uiManager.HideStartWave();
    }

    public void CloseLibraryPanel()
    {
        LibraryPanel.gameObject.SetActive(false);
        uiManager.CanOpenShopTrue();
        uiManager.CanOpenLibraryTrue();
        uiManager.CanOpenUpgradeSystemTrue();
        uiManager.ShowPauseBtn();
        uiManager.ShowStartWave();
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
