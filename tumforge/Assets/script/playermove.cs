using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
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


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        movement();
        jump = false;
    }

    public void Move(float move, bool jump)
    {

        
        if (m_Grounded || m_AirControl)
        {

            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }

        if (m_Grounded && jump)
        {
            m_Grounded = false;
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

    void GroundCheck()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * m_RunSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void movement()
    {
        Move(horizontalMove * Time.fixedDeltaTime, jump);
    }
}
