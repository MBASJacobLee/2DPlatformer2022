using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDataPersistence
{
    public int maxStamina = 10;
    public int maxJetpack = 5;
    public static int currentStamina;
    public int currentJet;
    float time;
    float timeDelay;
    public Staminabar StaminaBar;
    public Jetpack_bar Jetpack_bar;
    public Collider2D m_Collider;
    private int test = 0;

    //head check
    private bool isCellingBack;
    private bool isCellingFront;
    public Transform raycastStart;
    public Transform raycastStart2;
    public float checkRadius;
    
    public BoxCollider2D boxcol;
    public LayerMask laymask;
    public bool roof;
    public bool roof2;
    public bool crouching;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        //test for save system, didnt work
        //LoadData(this.info);
    }

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

    //this is the problem, this funcition is never called making the save system not work
    public void LoadData(GameData info) 
    {
        this.test = info.test;
        Debug.Log("player scrpit loading");
    }

    // for some reason this function is called when the other one is not.
    public void SaveData(GameData info) 
    {
        info.test = this.test;
        Debug.Log("save data player script ran");
    }

    //Important player crouch
    void crouch()
    {
        float extrahigtht = 0.1f;
        //raycast
        RaycastHit2D roofHit = Physics2D.Raycast(raycastStart.position, Vector2.up, 0.5f + extrahigtht, laymask);
        Color raycolour;
        if (roofHit.collider != null)
        {
            raycolour = Color.green;
        }else {
            raycolour = Color.red;
        }
        //debug ray
        Debug.DrawRay(raycastStart.position, Vector2.up * (0.5f + extrahigtht), raycolour, laymask);


        //second ray cast
        RaycastHit2D roofHit2 = Physics2D.Raycast(raycastStart2.position, Vector2.up, 0.5f + extrahigtht, laymask);
        Color raycolour2;
        if (roofHit2.collider != null)
        {
            raycolour2 = Color.green;
        }else {
            raycolour2 = Color.red;
        }
        //Debug ray 2
        Debug.DrawRay(raycastStart2.position, Vector2.up * (0.5f + extrahigtht), raycolour2, laymask);
        if (roofHit2.collider != null){
            roof2 = true;
        }
        else
        {
            roof2 = false;
        }
        //if player crouches, set this to true and false
        if (Input.GetButton("crouch"))
        {
            boxcol.enabled = false;
            crouching = true;
        }
        else
        {
            //if the player is still under roof but the user uncrouches, remain crouched
            if (roof || roof2)
            {
                crouching = true;
                boxcol.enabled = false;
            }
            else
            {
                //if the player is not under roof, uncrouch the player
                crouching = false;
                boxcol.enabled = true;
            }
        }
        //animator and the movement speed when the player is crouched
        if (crouching)
        {
            character_movement.targetSpeed = character_movement.crouchSpeed;
            anim.SetBool("Crouch", true);
        }
        //setting it back to normal when the player uncrouches
        else{
            character_movement.targetSpeed = 10f;
            anim.SetBool("Crouch", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // trails/Debuging from character crouching
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

        //stamina that was never fully implemented
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeStam(1);
            test += 1;
            Debug.Log(test);
        }
        //jetpack never fully implemented
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
        

        // more trailling/debuging for the character crouch

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
        //calling the crouch funcition
        crouch();
    }
    

    //everything bellow here works but was never fully implemented/tested in the game
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

