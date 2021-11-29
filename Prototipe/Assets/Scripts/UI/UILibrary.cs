using UnityEngine;
using System;

public class UILibrary : MonoBehaviour
{
    private GameManager gm;
    public GameObject libraryPanel;
    public Library library;
    public UIManager uiManager;
    private const int indexToActivate = 3;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        UIManager.InteractionWithUI += ActivateLibraryPanel;
    }

    public void ActivateLibraryPanel(int index)
    {
        if (index == indexToActivate && !uiManager.npc.activeSelf)
        {
            libraryPanel.gameObject.SetActive(true);
            //CursorController.instanceCursorController.ActivateNormalCursor();
            //CursorController.instanceCursorController.ActivateInvestigationCursor();
        }
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
            //CursorController.instanceCursorController.ActivateNormalCursor();
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
