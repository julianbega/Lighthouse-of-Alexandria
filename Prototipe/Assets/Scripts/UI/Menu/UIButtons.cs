using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtons : MonoBehaviour, IPointerEnterHandler
{
    public GameObject CanvasTest;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entro!");
        AkSoundEngine.PostEvent("ui_button_hover", CanvasTest);
    }
}
