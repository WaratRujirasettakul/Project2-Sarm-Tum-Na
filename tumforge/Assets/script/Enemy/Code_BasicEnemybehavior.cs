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
    bool wallinfront = false;
    bool wallbehind = false;
    float WallDetectRadius = 0.05f;
    public LayerMask WhatisWall;
    public Transform walldetectorfront;
    public Transform walldetectorback;
    bool theresgroundinfront = true;
    bool theresgroundbehind = true;
    float GroundDetectRadius = 0.05f;
    public LayerMask WhatisGround;
    public Transform grounddetectorfront;
    public Transform grounddetectorback;
    //---------------PlayerDetection--------------------
    public int detect_distance;
    public LayerMask WhatisPlayer;
    RaycastHit2D hit;
    public GameObject BEEB; //detect indicatior (can delete)
    public Transform CastPoint;
    public LayerMask obstacles;
    //------------------status-------------------------- //optimize needed
    public int e_health = 1;
    public int e_dam = 1;
    public float e_atktimer = 2f;
    //--------------------Others------------------------
    public Rigidbody2D Rigidbody;
    public GameObject player;
    public GameObject abilitycon;                        //optimize needed     
    bool playerinsight = false;
    float confusedtimer;
    public float confusedtime = 10;


    void awake()
    {
        dataset();
    }

    void FixedUpdate()
    {
        Statecheck();
    }

    void Update()
    {
        //print(abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        if (abilitycon.gameObject.GetComponent<Code_AbilityController>().timestoping == false)
        {
            if (foundplayer)
            {
                playerchase();
            }
            else
            {
                playerdetector(detect_distance);
                Counter();
                Movementstoper();
                Idle();
            }
        }

        if (e_health < 1)
        {
            Destroy(gameObject);
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
            if (theresgroundinfront && !wallinfront)
            {
                Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
            else
            {
                Flip();
                Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
        }
        else
        {
            if (theresgroundbehind && !wallbehind)
            {
                Flip();
                Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
            else
            {
                Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
        }
        Move_Counter = movementduration;
        yield return new WaitForSeconds(1.5f);
    }

    private IEnumerator Idle_moveL()
    {
        if (!facingright)
        {
            if (theresgroundinfront && !wallinfront)
            {
                Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
            else
            {
                Flip();
                Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
        }
        else
        {
            if (theresgroundbehind && !wallbehind)
            {
                Flip();
                Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
            else
            {
                Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y);
            }
        }
        Move_Counter = movementduration;
        yield return new WaitForSeconds(1.5f);
    }

    private void Counter()
    {
        Move_Counter -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
        Idle_counter -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
        confusedtimer -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;

        if (Move_Counter < 0)
        {
            Move_Counter = 0;
        }


    }

    private void dataset()
    {
        Idle_counter = Idle_delay;
        Move_Counter = movementduration;
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
                //idle animation?
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
        //will add the confused beheviour soon
        if ((this.transform.position.x - player.transform.position.x) > 0)
        {
            if (theresgroundinfront)
            {
                //player left
                if (facingright)
                {
                    Flip();
                    Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
                }
                else
                {
                    Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
                }
            }
            else
            {
                Rigidbody.velocity = Vector2.zero;
                foundplayer = false;
            }
        }
        else
        {
            if (theresgroundinfront)
            {
                //player right
                if (facingright)
                {
                    Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
                }
                else
                {
                    Flip();
                    Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
                }
            }
            else
            {
                Rigidbody.velocity = Vector2.zero;
                foundplayer = false;
            }
        }
    }

    private void playerdetector(float distance)
    {
        float castDist;

        if (facingright)
        {
            castDist = distance;
        }
        else
        {
            castDist = -distance;
        }

        Vector2 endPos = CastPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(CastPoint.position, endPos, obstacles);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                foundplayer = true;
                playerinsight = true;
                Debug.DrawLine(CastPoint.position, hit.point, Color.red);
            }
            Debug.DrawLine(CastPoint.position, hit.point, Color.blue);
        }
        else
        {
            Debug.DrawLine(CastPoint.position, endPos, Color.blue);
            playerinsight = false;
        }
    }
    
    void Statecheck()
    {
        wallinfront = Physics2D.OverlapCircle(walldetectorfront.position, WallDetectRadius, WhatisWall);
        wallbehind = Physics2D.OverlapCircle(walldetectorback.position, WallDetectRadius, WhatisWall);
        theresgroundinfront = Physics2D.OverlapCircle(grounddetectorfront.position, GroundDetectRadius, WhatisGround);
        theresgroundbehind = Physics2D.OverlapCircle(grounddetectorback.position, GroundDetectRadius, WhatisGround);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attacker")
        {
            e_health -= player.gameObject.GetComponent<Code_playermovement>().A_playerdam;
            print("attacked");
            print(e_health);
            print(player.gameObject.GetComponent<Code_playermovement>().A_playerdam);
        }
    }

}
