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
    public Collider2D m_Collider;
    //head check
    private bool isCellingBack;
    private bool isCellingFront;
    public Transform raycastStart;
    public Transform raycastStart2;
    public float checkRadius;
    //public LayerMask whatiscelling;
    
    public BoxCollider2D boxcol;
    public LayerMask laymask;
    public bool roof;
    public bool roof2;
    public bool crouching;


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
    
    void crouch()
    {
        float extrahigtht = 0.1f;
        RaycastHit2D roofHit = Physics2D.Raycast(raycastStart.position, Vector2.up, 0.9f + extrahigtht, laymask);
        /*Color raycolour;
        if (roofHit.collider != null)
        {
            raycolour = Color.green;
        }else {
            raycolour = Color.red;
        }*/
        //Debug.DrawRay(raycastStart.position, Vector2.up * (0.9f + extrahigtht), raycolour, laymask);



        RaycastHit2D roofHit2 = Physics2D.Raycast(raycastStart2.position, Vector2.up, 0.9f + extrahigtht, laymask);
       /* Color raycolour2;
        if (roofHit2.collider != null)
        {
            raycolour2 = Color.green;
        }else {
            raycolour2 = Color.red;
        }*/
        //Debug.DrawRay(raycastStart2.position, Vector2.up * (0.9f + extrahigtht), raycolour2, laymask);
        if (roofHit2.collider != null){
             roof2 = true;
             Debug.Log("rood true" + roofHit2.transform.name);
        }
        else
        {
            roof2 = false;
            Debug.Log("roof false");
        }
        if (Input.GetButton("crouch"))
        {
            boxcol.enabled = false;
            crouching = true;
        }
        else
        {
            if (roof || roof2)
            {
                crouching = true;
                boxcol.enabled = false;
            }
            else
            {
                crouching = false;
                boxcol.enabled = true;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D roofHit = Physics2D.Raycast(boxCol.bounds.center, Vector2.up, 2f, laymask);
        //isCellingFront = Physics2D.OverlapCircle(CellingCheckFront.position, checkRadius, whatiscelling);
        //isCellingBack = Physics2D.OverlapCircle(CellingCheckBack.position, checkRadius, whatiscelling);
        //isCelling = Physics2D.OverlapBox(CellingCheck, checkRadius, whatiscelling);
        
        /*if(hit.collider != null)
        {
            character_movement.roof_hit =  true;
        }
        else{
            character_movement.roof_hit = false;
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
        
        /*if(!character_movement.crouching)
        {
            if(character_movement.roof_hit)
            {
                m_Collider.enabled = true;
                
            }

        }
        if(character_movement.crouching)
        {
            if(!character_movement.roof_hit)
            {
                m_Collider.enabled = false;
            }
        }
        

        Debug.Log(isCellingFront);*/
    }

    void FixedUpdate()
    {
        crouch();
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

