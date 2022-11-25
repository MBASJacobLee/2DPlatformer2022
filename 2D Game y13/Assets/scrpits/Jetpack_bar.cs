using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack_bar : MonoBehaviour
{
    
    //slider for the jetpack bar
    public Slider slider;

    //max jetpack
    public void SetMaxJetpack(int Jetpack)
    {
        slider.maxValue = Jetpack;
        slider.value = Jetpack;
    }

    //more slider values
    public void SetJetpack(int Jetpack)
    {
        slider.value = Jetpack;
    }
}
