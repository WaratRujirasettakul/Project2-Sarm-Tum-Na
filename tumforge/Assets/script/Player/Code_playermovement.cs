﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_playermovement : MonoBehaviour
{
    //------------------Property------------------------
    [SerializeField] private float P_JumpForce = 400f;
    [Range(0, 100f)] [SerializeField] private float P_RunSpeed = 40f;
    [Range(0, .3f)] [SerializeField] private float P_MovementSmoothing = .05f;
    [SerializeField] private bool P_AirControl = false;
    private Code_Crosshair P_crossHair;
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
    public Animator animator;
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
    public float iframetimer = 0.3f;
    public float gravitytimer = 0.1f;

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
    public int A_playerdam = 1;
    public int A_playerhealth = 1;
    //--------------------ability-------------------------
    public GameObject abilitycon;

    // look at the enemy code and please add the timer using this code ( abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Player_FakeTime ) to the part that time will effect such as speed and duration.
    // if done please go tick the add timer to the code block in the trello's card  name "Timestop ability better version" and put the screen shot of the code or how the code work into the card
    private void Awake()
    {
        S_Rigidbody2D = GetComponent<Rigidbody2D>();
        P_Camera = GameObject.Find("Main Camera");
        P_crossHair = P_Camera.GetComponent<Code_Crosshair>();
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
            StartCoroutine(dashiframe());
            StartCoroutine(gravitys());
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
    }

    void Update()
    {
        animate();
        GroundCheck();
        OngroundEvent();
        character();
        Swhoosh_movement();

        stateReset();

        Death();

        control();
    }

    private IEnumerator dashiframe()
    {
        Physics2D.IgnoreLayerCollision(10,12,true);        
        yield return new WaitForSeconds(iframetimer);
        Physics2D.IgnoreLayerCollision(10,12,false);
    }

    private IEnumerator gravitys()
    {
        S_Rigidbody2D.gravityScale = 0f;
        yield return new WaitForSeconds(gravitytimer);
        S_Rigidbody2D.gravityScale = 2.1f;
    }
    void character()
    {
        M_horizontalMove = Input.GetAxisRaw("Horizontal") * P_RunSpeed;
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
        //----------------------------------------------------------------------------
        A_slashtime -= Time.deltaTime;

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
        //----------------------------------------------------------------------------
        if (!A_isAttacking)
        {
    
            if (A_slashnumber > 0 && slash)
            {
                LayerMask mask = LayerMask.GetMask("Enemy");
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
        }
    }

    void animate()
    {
        animator.SetBool("facingright", S_FacingRight);
    }

    void Death()
    {
        if (A_playerhealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void stateReset()
    {
        M_jump = false;
        M_dash = false;
        A_slash = false;
    }

    void control()
    {
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
}
