using UnityEngine;
using System;

public class UILibrary : MonoBehaviour
{
    private GameManager gm;
    public GameObject libraryPanel;
    public Library library;
    public UIManager uiManager;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        UIManager.InteractionWithUI += ActivateLibraryPanel;
    }

    public void ActivateLibraryPanel(int index)
    {
        if (index == 3 && !uiManager.npc.activeSelf)
            libraryPanel.gameObject.SetActive(true);
        else
            CloseLibraryPanel();
        uiManager.HidePauseBtn();
        uiManager.HideStartWave();
    }

    public void CloseLibraryPanel()
    {
        if (libraryPanel.gameObject.activeSelf)
        {
            libraryPanel.gameObject.SetActive(false);
            uiManager.ShowPauseBtn();
            uiManager.ShowStartWave();
        }
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
