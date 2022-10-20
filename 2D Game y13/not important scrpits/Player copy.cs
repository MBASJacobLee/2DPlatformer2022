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
    public Collider2D m_Collider;
    //head check
    private bool isCellingBack;
    private bool isCellingFront;
    public Transform CellingCheckBack;
    public Transform CellingCheckFront;
    public float checkRadius;
    public LayerMask whatiscelling;
    
    public BoxCollider2D boxcol;
    public LayerMask laymask;


    void Start()
    {
        time = 0f;
        timeDelay = 2f;
        currentStamina = maxStamina;
        currentJet = maxJetpack;
        StaminaBar.SetMaxStamina(maxStamina);
        Jetpack_bar.SetMaxJetpack(maxJetpack);
        m_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(boxcol.bounds.center, Vector2.up, boxcol.bounds.extents.y +0.1f, laymask);
        isCellingFront = Physics2D.OverlapCircle(CellingCheckFront.position, checkRadius, whatiscelling);
        isCellingBack = Physics2D.OverlapCircle(CellingCheckBack.position, checkRadius, whatiscelling);
        //isCelling = Physics2D.OverlapBox(CellingCheck, checkRadius, whatiscelling);
        
        /*if(hit.collider != null)
        {
            character_movement.crouching = true;
        }
        else{
            character_movement.crouching = false;
        }*/
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
        
        if(!character_movement.crouching)
        {
            if(isCellingBack && isCellingFront)
            {
                m_Collider.enabled = true;
                
            }

        }
        if(character_movement.crouching)
        {
            if(!isCellingBack || !isCellingFront)
            {
                m_Collider.enabled = false;
            }
        }
        

        Debug.Log(isCellingFront);
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

