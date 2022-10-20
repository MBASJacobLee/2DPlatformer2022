using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hello
public class character_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    //movement variables
    public float moveSpeed = 0.3f;
    private float targetSpeed = 10f;
    private float sprintSpeed = 15f; 
    private float accelerRate = 1f;
    private float deaccelerRate = 5f;
    private float crouchSpeed = 2f;
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
    private bool candoublejump = true;
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
            targetSpeed = crouchSpeed;
        }
        else
        {
            targetSpeed = 10f;
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        pnhorizontal = Input.GetAxisRaw("Horizontal"); 

        if (pnhorizontal > 0.1f)
        {
            transform.eulerAngles = new Vector2(0,180);
        }
        if (pnhorizontal < -0.1f)
        {
            transform.eulerAngles = new Vector2(0,0);
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisground);

        /*if(isGrounded && Input.GetKeyDown(KeyCode.Space)) || jumprate <= 5 && Input.GetKeyDown(KeyCode.Space))
        {
              rb.velocity = Vector2.up * jumpforce;
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpforce;
                candoublejump = true;

            } 
            else
            if (candoublejump) 
            {
                candoublejump = false;
                rb.velocity = Vector2.up * jumpforce;

            }
            
        }

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

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		/*m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector2 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;*/
        transform.eulerAngles = new Vector2(0,180);
	}
    
     private void Flip2()
	{
        transform.eulerAngles = new Vector2(0,0);
	}
}
