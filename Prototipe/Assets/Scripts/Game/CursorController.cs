using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    static public CursorController instanceCursorController;
    static public CursorController Get { get { return instanceCursorController; } }

    public Texture2D normalCursor, constructionCursor, investigationCursor, upgradeCursor, transparentCursor;

    private void Awake()
    {
        if (instanceCursorController != this && instanceCursorController != null)
            Destroy(gameObject);
        else
            instanceCursorController = this;
    }

    public void ActivateNormalCursor()
    {
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ActivateConstructionCursor()
    {
        Cursor.SetCursor(constructionCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ActivateInvestigationCursor()
    {
        Cursor.SetCursor(investigationCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ActivateUpgradeCursor()
    {
        Cursor.SetCursor(upgradeCursor, Vector2.zero, CursorMode.Auto);
    }

    public void ActivateTransparentCursor()
    {
        Cursor.SetCursor(transparentCursor, Vector2.zero, CursorMode.Auto);
    }
}
