using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxStamina = 10;
    public int currentStamina;
    float time;
    float timeDelay;
    public Staminabar StaminaBar;

    void Start()
    {
        time = 0f;
        timeDelay = 8f;
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

        time = time + 1f * Time.deltaTime;
        if (time >= timeDelay)
        {
            time = 0f;
            if(currentStamina < maxStamina)
            {
                UpStam(1);
            }
        }
        
    }
    void TakeStam(int stam)
    {
        currentStamina -= stam;

        StaminaBar.SetStamina(currentStamina);
    }

    void UpStam (int stam2)
    {
        
        currentStamina += stam2;

        StaminaBar.SetStamina(currentStamina);
    }
}
