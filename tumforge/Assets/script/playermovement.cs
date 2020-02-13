using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    //------------------Property------------------------
    [SerializeField] private float P_JumpForce = 400f;
    [Range(0, 100f)] [SerializeField] private float P_RunSpeed = 40f;
    [Range(0, .3f)] [SerializeField] private float P_MovementSmoothing = .05f;
    [SerializeField] private bool P_AirControl = false;
    private Crosshair P_crossHair;
    private GameObject P_Camera;
    //---------------characterstate---------------------
    [SerializeField] private LayerMask S_WhatIsGround;
    [SerializeField] private Transform S_GroundCheck;
    const float S_GroundedRadius = .2f;
    private bool S_Grounded;
    private Rigidbody2D S_Rigidbody2D;
    private bool S_FacingRight = true;
    private Vector3 S_Velocity = Vector3.zero;
    //-------------------movement-----------------------
    float M_horizontalMove = 0f;
    bool M_jump = false;
    bool M_dash = false;
    public GameObject M_canflip;
    //public SpriteRenderer spriteRen; //not in use
    //--------------------jump--------------------------
    public int J_jumplimit = 2;
    int J_jumpnumber;
    //-------------------dashing------------------------
    public int D_dashlimit = 2;
    int D_dashnumber;
    public float D_dashtimeValue = 0.1f;
    float D_dashtime;
    public float D_dashvelocity = 120;
    bool D_isdashing = false;
    Vector2 speed_before_dash;
    //-------------------attacking-----------------------
    bool A_slash = false;
    public GameObject A_SWHOOSH;
    private float A_rotaion;
    int A_slashlimit = 2;
    int A_slashnumber;
    public float A_slashtimevalue = 0.1f;
    float A_slashtime;
    public float A_slashvelocity = 120;
    bool A_isAttacking = false;
    Vector2 speed_before_slash;




    private void Awake()
    {
        S_Rigidbody2D = GetComponent<Rigidbody2D>();
        P_Camera = GameObject.Find("Main Camera");
        P_crossHair = P_Camera.GetComponent<Crosshair>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
        OngroundEvent();
        character();
        Swhoosh_movement();
        M_jump = false;
        M_dash = false;
        A_slash = false;
    }

    public void Move(float move, bool jump, bool dash)
    {
        D_dashtime -= Time.deltaTime;

        if (S_Grounded || P_AirControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, S_Rigidbody2D.velocity.y);

            S_Rigidbody2D.velocity = Vector3.SmoothDamp(S_Rigidbody2D.velocity, targetVelocity, ref S_Velocity, P_MovementSmoothing);

            if (move > 0 && !S_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && S_FacingRight)
            {
                Flip();
            }
        }
        if (J_jumpnumber > 0 && jump)
        {
            S_Rigidbody2D.velocity = new Vector2(S_Rigidbody2D.velocity.x, 0);
            S_Grounded = false;
            S_Rigidbody2D.AddForce(new Vector2(0f, P_JumpForce));
            J_jumpnumber -= 1;
        }
        //------------------dash-----------------
        if (D_dashnumber > 0 && dash)
        {
            speed_before_dash = new Vector2(S_Rigidbody2D.velocity.x, S_Rigidbody2D.velocity.y);
            D_dashnumber -= 1;
            D_isdashing = true;
            D_dashtime = D_dashtimeValue;
        }
        if (D_dashtime > 0 && D_isdashing)
        {
            if (S_FacingRight)
            {
                S_Rigidbody2D.velocity = new Vector2(D_dashvelocity, 0);
            }
            else
            {
                S_Rigidbody2D.velocity = new Vector2(-D_dashvelocity, 0);
            }
        }
        if ((D_dashtime < 0.07) && (D_dashtime > 0.0001) && (D_isdashing = true))
        {
            D_isdashing = false;
            S_Rigidbody2D.velocity = speed_before_dash;
        }
        if (D_dashtime < 0)
        {
            D_dashtime = 0;
        }
    }

    private void Flip()
    {
        S_FacingRight = !S_FacingRight;

        Vector3 theScale = M_canflip.transform.localScale;
        theScale.x *= -1;
        M_canflip.transform.localScale = theScale;

        //spriteRen.flipX = !spriteRen.flipX;
    }

    void Update()
    {
        //print(A_rotaion);
        M_horizontalMove = Input.GetAxisRaw("Horizontal") * P_RunSpeed;

        if ((Input.GetButtonDown("Jump")))
        {
            M_jump = true;
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetKeyDown(KeyCode.LeftShift))
        {
            M_dash = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            A_slash = true;
        }
    }


    void character()
    {
        Move(M_horizontalMove * Time.fixedDeltaTime, M_jump, M_dash);
        Slash(A_slash);
    }

    void GroundCheck()
    {
        bool wasGrounded = S_Grounded;
        S_Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(S_GroundCheck.position, S_GroundedRadius, S_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                S_Grounded = true;
            }
        }
    }

    void OngroundEvent()
    {
        if (S_Grounded)
        {
            J_jumpnumber = J_jumplimit;
            D_dashnumber = D_dashlimit;
            A_slashnumber = A_slashlimit;
        }

    }

    void Swhoosh_movement()
    {
        A_rotaion = P_crossHair.rotationz;
        A_SWHOOSH.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -A_rotaion);
    }

    void Slash(bool slash)
    {
        A_slashtime -= Time.deltaTime;

        if (A_slashnumber > 0 && slash)
        {
            speed_before_slash = new Vector2(S_Rigidbody2D.velocity.x, S_Rigidbody2D.velocity.y);
            A_SWHOOSH.SetActive(true);
            A_slashnumber -= 1;
            A_isAttacking = true;
            A_slashtime = A_slashtimevalue;
        }
        if (A_slashtime > 0 && A_isAttacking)
        {
            S_Rigidbody2D.velocity = P_crossHair.direction * A_slashvelocity;

            if (S_FacingRight && (A_rotaion <= 0))
            {
                Flip();
            }
            else if (!S_FacingRight && (A_rotaion >= 0))
            {
                Flip();
            }
        }
        if ((A_slashtime < 0.07) && (A_slashtime > 0.0001) && (A_isAttacking = true))
        {
            A_isAttacking = false;
            S_Rigidbody2D.velocity = speed_before_slash;
            A_SWHOOSH.SetActive(false);
        }
        if (A_slashtime < 0)
        {
            A_slashtime = 0;
        }
    }

}

