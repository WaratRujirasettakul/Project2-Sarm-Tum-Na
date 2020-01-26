using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                         
    [Range(0, 100f)] [SerializeField] private float m_RunSpeed = 40f;          
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  
    [SerializeField] private bool m_AirControl = false;                       
    [SerializeField] private LayerMask m_WhatIsGround;                          
    [SerializeField] private Transform m_GroundCheck;
    //--------------------------------------------------
    const float k_GroundedRadius = .2f; 
    private bool m_Grounded;           
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  
    private Vector3 m_Velocity = Vector3.zero;
    //--------------------------------------------------
    float horizontalMove = 0f;
    bool jump = false;
    public GameObject canflip;
    public float dashspeed;
    public float dashtime;
    public float startdashtime;
    private int direction;
    public int jumplimit = 1;
    public int airdashlimit = 2;
    private bool onground = true;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        dashtime = startdashtime;
    }

    private void FixedUpdate()
    {
     //   GroundCheck();
        movement();
        jump = false;
    }

    public void Move(float move, bool jump)
    {

        
        if (onground = true || m_AirControl)
        {

            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if ((move > 0) && (!m_FacingRight))
            {
                Flip();
            }
            else if ((move < 0) && (m_FacingRight))
            {
                Flip();
            }
        }

        if ((jumplimit > 0) && jump)
        {
            onground = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = canflip.transform.localScale;
        theScale.x *= -1;
        canflip.transform.localScale = theScale;
    }

    //void GroundCheck()
    //{
     //   bool wasGrounded = m_Grounded;
    //    m_Grounded = false;

      //  Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
     //   for (int i = 0; i < colliders.Length; i++)
     //   {
     //       if (colliders[i].gameObject != gameObject)
     //       {
     //           m_Grounded = true;
     //       }
      //  }
   // }

    void Update()
    {
        print(onground);
        horizontalMove = Input.GetAxisRaw("Horizontal") * m_RunSpeed;

        if ((Input.GetButtonDown("Jump"))&&(jumplimit > 0))
        {
            jump = true;
            jumplimit -= 1;
            

        }
        if (direction == 0)
        {
            if ((Input.GetKey(KeyCode.D))&& (Input.GetKeyDown(KeyCode.LeftShift)))
            {
                direction = 1;
            }else if ((Input.GetKey(KeyCode.A))&& (Input.GetKeyDown(KeyCode.LeftShift)))
            {
                direction = 2;
            }
        }
        else if ((direction != 0)&&(jumplimit == 2))
        {
            if(dashtime <= 0)
            {
                direction = 0;
                dashtime = startdashtime;
                m_Rigidbody2D.velocity = Vector2.zero; 
            } else
            {
                dashtime -= Time.deltaTime;

                if(direction == 1)
                {
                    m_Rigidbody2D.velocity = Vector2.right * dashspeed;
                }else if(direction == 2){
                    m_Rigidbody2D.velocity = Vector2.left * dashspeed;
                }
            }
        }
        else if ((direction != 0) && (jumplimit < 2))
        {
            if (dashtime <= 0)
            {
                direction = 0;
                dashtime = startdashtime;
                m_Rigidbody2D.velocity = Vector2.zero;
                
            }
            else
            {
                dashtime -= Time.deltaTime;

                if ((direction == 1) && (airdashlimit > 0))
                {
                    m_Rigidbody2D.velocity = Vector2.right * dashspeed;
                    airdashlimit -= 1;
                }
                else if ((direction == 2)&& (airdashlimit > 0))
                {
                    m_Rigidbody2D.velocity = Vector2.left * dashspeed;
                    airdashlimit -= 1;
                }
            }
        }
    }

   
    void movement()
    {
        Move(horizontalMove * Time.fixedDeltaTime, jump);
    }

}
