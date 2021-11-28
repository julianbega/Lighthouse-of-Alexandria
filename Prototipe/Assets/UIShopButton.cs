using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIShopButton : MonoBehaviour, IPointerEnterHandler
{
    public TextMeshProUGUI price;
    public int towerPrice;

    public void OnPointerEnter(PointerEventData eventData)
    {
        price.text = "Cost " + towerPrice;
    }
}
