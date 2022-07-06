using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxStamina = 10;
    public int maxJetpack = 5;
    public int currentStamina;
    public int currentJet;
    float time;
    float timeDelay;
    public Staminabar StaminaBar;
    public Jetpack_bar Jetpack_bar;
    bool player_sprinting = false;


    void Start()
    {
        time = 0f;
        timeDelay = 2f;
        currentStamina = maxStamina;
        currentJet = maxJetpack;
        StaminaBar.SetMaxStamina(maxStamina);
        Jetpack_bar.SetMaxJetpack(maxJetpack);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeStam(1);
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            Takejet(1);
        }

        time = time + Time.deltaTime;
        if (time >= timeDelay)
        {
            time = 0f;
            if(currentStamina < maxStamina)
            {
                UpStam(1);
            }
        

            if(currentJet < maxJetpack)
            {
                UpJet(1);
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

    void Takejet(int Jetpack)
    {
        currentJet -= Jetpack;

        Jetpack_bar.SetJetpack(currentJet);
    }

    void UpJet (int Jetpack2)
    {
        
        currentJet += Jetpack2;

        Jetpack_bar.SetJetpack(currentJet);
    }
}
