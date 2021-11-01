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
        UIManager.InteractionWithUI += ActivateLibraryPanel;
    }

    public void ActivateLibraryPanel(int index)
    {
        if(index == 1 && !uiManager.NPC.activeSelf)
            LibraryPanel.gameObject.SetActive(true);
        uiManager.HidePauseBtn();
        uiManager.HideStartWave();
    }

    public void CloseLibraryPanel()
    {
        LibraryPanel.gameObject.SetActive(false);
        uiManager.ShowPauseBtn();
        uiManager.ShowStartWave();
    }

    public void UnlockTurret(int index)
    {
        library.turretUnlocked[index] = true;
    }

    private void OnDisable()
    {
        UIManager.InteractionWithUI -= ActivateLibraryPanel;
    }
}
