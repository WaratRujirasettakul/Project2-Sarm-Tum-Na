using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_BasicEnemybehavior : MonoBehaviour
{
    //-------------------movement-----------------------
    private int Idle_action;
    public float Idle_delay = 5f;
    float Idle_counter;
    public float movementspeed = 20f;
    float Move_Counter;
    public float movementduration = 0.5f;
    public float basemovespeed;
    //---------------characterstate---------------------
    bool facingright = true;
    bool foundplayer = false;
    //---------------PlayerDetection--------------------
    public int detect_distance;
    public LayerMask WhatisPlayer;
    
    RaycastHit2D hit;
    public GameObject BEEB; //detect indicatior (can delete)
    public Transform origin;
    //public GameObject Player;
    //--------------------Others------------------------
    public Rigidbody2D Rigidbody;
    public GameObject player;
    //-------------------Player chase-------------------
    private float mycurpos;
    private float ppos;
    private float distance;
    public bool wallcol = false;
    //-------------------Health&Damage------------------
    public int e_health = 1;
    public int e_dam = 1;
    public float e_atktimer = 2f;
    //--------------------timer-------------------------
    public GameObject abilitycon;
    

    void awake()
    {
        dataset();
        Rigidbody = transform.GetComponent<Rigidbody2D>();
        basemovespeed = movementspeed;
        
    }

    void FixedUpdate()
    {
        if (foundplayer)
        {
            //do something
            print("detected");
            playerchase();
        }
        else
        {
            playerdetector();
            
            Counter();
            Movementstoper();
            Idle();
        }

        if (e_health == 0)
        {
            Destroy(this.gameObject);
        }
        
    }
    void Update()
    {
        if (e_health == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }

    private IEnumerator Idle_moveR()
    {
        if (!wallcol)
        {
            if (facingright)
            {
                Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
            else
            {
                Flip();
                Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
        }
        else
        {
            Flip();
            Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
        }
        Move_Counter = movementduration;
        yield return new WaitForSeconds(1.5f);
    }

    private IEnumerator Idle_moveL()
    {
        if (!wallcol)
        {
            if (!facingright)
            {
                Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
            else
            {
                Flip();
                Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
        }
        else
        {
            Flip();
            Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
        }
        Move_Counter = movementduration;
        yield return new WaitForSeconds(1.5f);
    }

    private void Counter()
    {
        Move_Counter -= Time.deltaTime*abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
        Idle_counter -= Time.deltaTime*abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;

        if (Move_Counter < 0)
        {
            Move_Counter = 0;
        }
    }

    private void dataset()
    {
        
        Idle_counter = Idle_delay;
        Move_Counter = movementduration;
        //player = GameObject.Find("player");
    }

    private void Idle()
    {
        if (Idle_counter <= 1)
        {
            Idle_action = Random.Range(0, 5);
            if (Idle_action == 1)
            {
                Flip();
                //print("flip");
            }
            else if (Idle_action == 2)
            {
                StartCoroutine(Idle_moveR());
                //print("Idle_moveR");
            }
            else if (Idle_action == 3)
            { 
                StartCoroutine(Idle_moveL());
                //print("Idle_movel");
            }
            else
            {
                //idle
                //print("idle");
            }

            Idle_counter = Idle_delay;
        }
    }

    private void Movementstoper()
    {
        if ((Move_Counter < 0.07) && (Move_Counter > 0.0001))
        {
            this.Rigidbody.velocity = new Vector2(0,0);
        }
    }
    private void playerchase() 
    {
        ppos = player.transform.position.x;
        print(ppos);
        mycurpos = transform.position.x;
        distance = mycurpos - ppos;
        if(distance > 0)
        {
            if (!wallcol)
            {
                if (!facingright)
                {
                    Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
                }
                else
                {
                    Flip();
                    Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
                }
            }
           // else  *for animation condition
           // {
                
                
           // }
        }
        else
        {
            if (!wallcol)
            {
                if (facingright)
                {
                    Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
                }
                else
                {
                    Flip();
                    Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
                }
            }
            // else  *for animation condition
            // {


            // }
        }

    }
    private void playerdetector()
    {
        LayerMask mask = LayerMask.GetMask("Wall");
        if (facingright)
        {
            //if(Physics2D.Raycast(origin.position, new Vector2(1, 0), detect_distance, mask))
            //{
            
            //}else 
            if (Physics2D.Raycast(origin.position, new Vector2(1, 0), detect_distance, WhatisPlayer))
            {
                foundplayer = true;
                BEEB.SetActive(true);
            }
            else { BEEB.SetActive(false); }
        }
        else
        {


            //if (Physics2D.Raycast(origin.position, new Vector2(-1, 0), detect_distance, mask))
            //{

            //}
            //else 
            if (Physics2D.Raycast(origin.position, new Vector2(-1,0), detect_distance, WhatisPlayer))
            {
                foundplayer = true;
                BEEB.SetActive(true);
            }
            else { BEEB.SetActive(false); }
        }
    }

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attacker")
        {
            e_health -= player.gameObject.GetComponent<Code_playermovement>().A_playerdam;
        }
    }

}
