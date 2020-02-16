using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_BasicEnemybehavior : MonoBehaviour
{
    //-------------------movement-----------------------
    private int Idle_action;
    public float Idle_delay = 5f;
    float Idle_counter;
    public float movementspeed = 20;
    float Move_Counter;
    public float movementduration = 0.5f;
    //---------------characterstate---------------------
    bool facingright = true;
    bool foundplayer = false;
    //---------------PlayerDetection--------------------
    public int detect_distance;
    public LayerMask WhatisPlayer;
    RaycastHit2D hit;
    public GameObject BEEB; //detect indicatior (can delete)
    //--------------------Others------------------------
    Rigidbody2D Rigidbody;
    GameObject player;

    void awake()
    {
        dataset();
    }

    void Update()
    {
        if (foundplayer)
        {
            //do something
        }
        else
        {
            playerdetector();
            Counter();
            Movementstoper();
            Idle();
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
        if (facingright)
        {
            Rigidbody.velocity = new Vector2(movementspeed, Rigidbody.velocity.y);
        }
        else
        {
            Flip();
            Rigidbody.velocity = new Vector2(movementspeed, Rigidbody.velocity.y);
        }
        Move_Counter = movementduration;
        yield return new WaitForSeconds(1.5f);
    }

    private IEnumerator Idle_moveL()
    {
        if (!facingright)
        {
            Rigidbody.velocity = new Vector2(-movementspeed, Rigidbody.velocity.y);
        }
        else
        {
            Flip();
            Rigidbody.velocity = new Vector2(-movementspeed, Rigidbody.velocity.y);
        }
        Move_Counter = movementduration;
        yield return new WaitForSeconds(1.5f);
    }

    private void Counter()
    {
        Move_Counter -= Time.deltaTime;
        Idle_counter -= Time.deltaTime;

        if (Move_Counter < 0)
        {
            Move_Counter = 0;
        }
    }

    private void dataset()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Idle_counter = Idle_delay;
        Move_Counter = movementduration;
        player = GameObject.Find("player");
    }

    private void Idle()
    {
        if (Idle_counter <= 1)
        {
            Idle_action = Random.Range(0, 10);
            if (Idle_action == 1)
            {
                Flip();
            }
            else if (Idle_action == 2)
            {
                StartCoroutine(Idle_moveR());
            }
            else if (Idle_action == 3)
            { 
                StartCoroutine(Idle_moveL());
            }
            else
            {
                //idle
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

    private void playerdetector()
    {
        if (facingright)
        {
            if (Physics2D.Raycast(this.transform.position, new Vector2(1, 0), detect_distance, WhatisPlayer))
            {
                //foundplayer = true;
                BEEB.SetActive(true);
            }
            else BEEB.SetActive(false);
        }
        else
        {
            if (Physics2D.Raycast(this.transform.position, new Vector2(-1,0), detect_distance, WhatisPlayer))
            {
                //foundplayer = true;
                BEEB.SetActive(true);
            }
            else BEEB.SetActive(false);
        }
    }
}
