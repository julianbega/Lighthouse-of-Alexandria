using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public GameObject CanvasTest;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Entro!");
        AkSoundEngine.PostEvent("ui_button_hover", CanvasTest);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AkSoundEngine.PostEvent("ui_button_click", CanvasTest);
    }
}
