using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    //slider for the stamina bar
    public Slider slider;

    public void SetMaxStamina(int Stamina)
    {
        slider.maxValue = Stamina;
        slider.value = Stamina;
    }

    public void SetStamina(int Stamina)
    {
        slider.value = Stamina;
    }
}
