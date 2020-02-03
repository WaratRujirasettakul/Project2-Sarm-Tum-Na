using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
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
    bool dash = false;
    public GameObject canflip;
    public SpriteRenderer spriteRen;

    public int jumplimit = 2;
    int jumpnumber;

    private float rotatez = 0.0f; // new
    public int dashlimit = 2;
    int dashnumber;

    public float dashtimeValue = 0.1f;
    float dashtime;
    public float dashvelocity = 120;
    bool isdashing = false;
    Vector2 speed_before_dash;
    public GameObject AttackWindow;
    public float A_atttackDuration = 0f;
    public float A_attackSpeed = 0f;
    public float A_attackVelocity = 0f;
    Vector2 A_direction;
    public GameObject swoosh;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        OngroundEvent();
        movement();
        jump = false;
        dash = false;
    }

    public void Move(float move, bool jump, bool dash)
    {
        dashtime -= Time.deltaTime;

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
        if (jumpnumber > 0 && jump)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            jumpnumber -= 1;
        }
        //------------------dash-----------------
        if (dashnumber > 0 && dash)
        {
            speed_before_dash = new Vector2(m_Rigidbody2D.velocity.x, m_Rigidbody2D.velocity.y);
            dashnumber -= 1;
            isdashing = true;
            dashtime = dashtimeValue;
        }
        if (dashtime > 0 && isdashing)
        {
            if (m_FacingRight)
            {
                m_Rigidbody2D.velocity = new Vector2(dashvelocity, 0);
            }
            else
            {
                m_Rigidbody2D.velocity = new Vector2(-dashvelocity, 0);
            }
        }
        if (dashtime == 0.1)
        {
            m_Rigidbody2D.velocity = speed_before_dash;
            isdashing = false;
        }
        if (dashtime < 0)
        {
            dashtime = 0;
        }
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = canflip.transform.localScale;
        theScale.x *= -1;
        canflip.transform.localScale = theScale;

        spriteRen.flipX = !spriteRen.flipX;
    }

    void Update()
    {
        print(isdashing);
        print(dashtime);
        horizontalMove = Input.GetAxisRaw("Horizontal") * m_RunSpeed;

        if ((Input.GetButtonDown("Jump")))
        {
            jump = true;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash = true;
        }

        if (A_atttackDuration <= 0)
        {
            swoosh.SetActive(false);
            if (Input.GetMouseButton(0))
            {
                A_atttackDuration = A_attackSpeed;
                playeratk();
            }



        }
        else
        {
            A_atttackDuration -= Time.deltaTime;

        }
    }

    void playeratk()
    {
        GameObject Thecam = GameObject.Find("Main Camera");
        Crosshair crossHair = Thecam.GetComponent<Crosshair>();
        rotatez = crossHair.rotationz;
        A_direction = crossHair.direction;
        swoosh.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -rotatez);
        swoosh.SetActive(true);
        m_Rigidbody2D.velocity = A_direction * A_attackVelocity;


    }
    void movement()
    {
        Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
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

    void OngroundEvent()
    {
        if (m_Grounded)
        {
            jumpnumber = jumplimit;
            dashnumber = dashlimit;
        }
    }

}

