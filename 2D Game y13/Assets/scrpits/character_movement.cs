using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hello
public class character_movement : MonoBehaviour
{
    // all of the variables
    public static character_movement instance;
    private Rigidbody2D rb;
    //movement variables
    public static float moveSpeed = 0.3f;
    public static float targetSpeed = 10f;
    public static float sprintSpeed = 15f; 
    public static float accelerRate = 1f;
    public static float deaccelerRate = 5f;
    public static float crouchSpeed = 2f;
    public float jumprate = 6f;
    // Something important
    private float pnhorizontal;
    // to check if is grounded and feet positions
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;

    public LayerMask whatisground;
    //Jumping variables
    public float jumpforce;
    private bool candoublejump;
    private float jpack = 15f;
    //Time delay for decressing jetpack
    float time;
    float timeDelay;
    //Time delay for increassing jetpack
    float time2;
    float timeDelay2;
    // Sinking weight things
    public float downforce;
    private float maxjpack =  15f;
    // Crouching variables
    [SerializeField] public static bool crouching = false;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public static bool roof_hit = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        time = 0f;
        timeDelay = 0.3f;
        time2 = 0f;
        timeDelay2 = 5f;
    }

    void FixedUpdate()
    {
        //moving
        rb.velocity = new Vector2(pnhorizontal * moveSpeed, rb.velocity.y );
        if (Input.GetButton ("Horizontal"))
        {
            if (moveSpeed < targetSpeed)
            {
                moveSpeed += accelerRate;
            }
            else if (moveSpeed > targetSpeed)
            {
                moveSpeed = targetSpeed;
            }
        }
        else 
        {
            moveSpeed -= deaccelerRate;
            if (moveSpeed < 0.3f )
            {
                moveSpeed = 0f;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetSpeed = sprintSpeed;
        }
        else
        {
            targetSpeed = 10f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            
        }
        else
        {
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        //getting raw player inputs
        pnhorizontal = Input.GetAxisRaw("Horizontal"); 

        if(pnhorizontal == 0f)
        {
            anim.SetBool("moving", false);
        }

        if (pnhorizontal > 0.1f)
        {
            transform.eulerAngles = new Vector2(0,0);
            anim.SetBool("moving", true);
        }
        if (pnhorizontal < -0.1f)
        {
            transform.eulerAngles = new Vector2(0,180);
            anim.SetBool("moving", true);
        }

        //checking if player is grounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        /*if(isGrounded && Input.GetKeyDown(KeyCode.Space)) || Input.GetKeyDown(KeyCode.Space)
        {
            rb.velocity = Vector2.up * jumpforce;
        }*/

        /*if (Input.GetKey(KeyCode.W))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpforce;
                candoublejump = true;
                Debug.Log(candoublejump);
            } 
            else{}
            if (candoublejump && Input.GetKey(KeyCode.W)) 
            {
                candoublejump = false;
                Debug.Log(candoublejump);
                rb.velocity = Vector2.up * jumpforce;
                Debug.Log("doublejumped");

            }else{}
            
        }*/


        if(isGrounded && !Input.GetKeyDown(KeyCode.W))
        {
            candoublejump = false;
        }


        //jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded || candoublejump)
            {
                rb.velocity = Vector2.up * jumpforce;
                candoublejump = !candoublejump;
                Debug.Log(candoublejump);
            }
            
        }

        //Jetpack feature that was never full implemneted
        if (Input.GetKey(KeyCode.V))
        {
            if(jpack <= 15f)
            {
                rb.velocity = Vector2.up * jumpforce;
                time = time + Time.deltaTime;
                if (time >= timeDelay)
                {
                    time = 0f;
                    jpack -= 1;
                    Debug.Log(jpack);
                } 
            }
            if(jpack == 0)
            {
                jpack = jpack + 1;
                Debug.Log(jpack);
            }
        }

        time2 = time2 + Time.deltaTime;
        if (time2 >= timeDelay2)
        {
            time2 = 0f;
            if(jpack < maxjpack)
            {
                UpJpack(1);
            }
        }
		
    }

    //Jetpack feature that was never full implemneted
    void UpJpack(int Jpack2)
    {
        if (jpack <= maxjpack)
        {
            jpack += Jpack2;
            Debug.Log("cock");
            Debug.Log(jpack);
        }
        
        else{

        }
    }
}
