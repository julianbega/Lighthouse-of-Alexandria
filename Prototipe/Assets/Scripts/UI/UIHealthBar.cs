using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int heath)
    {
        slider.maxValue = heath;
        slider.value = heath;
    }
    public void SetHealth(int heath)
    {
        slider.value = heath;
    }
}
