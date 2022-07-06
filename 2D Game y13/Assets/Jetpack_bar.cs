using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack_bar : MonoBehaviour
{
    
    public Slider slider;

    public void SetMaxJetpack(int Jetpack)
    {
        slider.maxValue = Jetpack;
        slider.value = Jetpack;
    }

    public void SetJetpack(int Jetpack)
    {
        slider.value = Jetpack;
    }
}
