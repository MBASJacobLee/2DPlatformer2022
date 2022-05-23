using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxStamina = 10;
    public int currentStamina;

    public Staminabar StaminaBar;
    void Start()
    {
        currentStamina = maxStamina;
        StaminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeStam(1);
        }
    }
    void TakeStam(int stam)
    {
        currentStamina -= stam;

        StaminaBar.SetStamina(currentStamina);
    }
}
