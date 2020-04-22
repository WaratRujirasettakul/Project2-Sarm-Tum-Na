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
    public bool facingright = true;
    public bool foundplayer = false;
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

    public float confusedtimer;
    public float confusedduration = 3f;
    float playertimer;
    public float playerdetectduration = 3f;

    public bool confused;
    bool couroutinerun = false;
    public GameObject attacker;

    public Animator animator;
    bool run;
    bool attack;
    bool idle;

    [Header("Effect")]
    public GameObject effectWhenDestroyed;

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

        /*/if (abilitycon.gameObject.GetComponent<Code_AbilityController>().timestoping == false)
        {
            if (foundplayer && (!confusestate))
            {
                playerchase();
                playerdetector(detect_distance);
            }
            else if (!foundplayer && (!confusestate))
            {
                playerdetector(detect_distance);
                Counter();
                Movementstoper();
                Idle();
            }
            else if (confusestate)
            {
                if (!couroutinerun)
                {
                    couroutinerun = true;

                    StartCoroutine(Confused());
                }
            }
        }/*/

        playerdetector(detect_distance);
        Counter();
        animate();

        if (abilitycon.gameObject.GetComponent<Code_AbilityController>().timestoping == false)
        {
            if (!foundplayer)
            {
                idle = true;
                if (confused)
                {
                    if (couroutinerun == false)
                    {
                        StartCoroutine(Confused());
                    }
                }
                else
                {
                    Idle();
                    Movementstoper();
                }

            }
            else
            {
                idle = false;
                playerchase();
            }
               
        }

        if (e_health < 1)
        {
            Instantiate(effectWhenDestroyed, transform.position, Quaternion.identity);
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
    private IEnumerator Confused()
    {
        couroutinerun = true;
        Flip();
        yield return new WaitForSeconds(1f *abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        couroutinerun = false;
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
        confusedtime();
        detecttime();

        Move_Counter -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
        Idle_counter -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
        confusedtimer -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
        playertimer -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;

        if (Move_Counter < 0)
        {
            Move_Counter = 0;
        }

        if (confusedtimer < 0)
        {
            confusedtimer = 0;
        }

        if (playertimer < 0)
        {
            playertimer = 0;
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
        if (attacker.gameObject.GetComponent<Code_isattacking>().isattacking)
        {
            //will add the confused beheviour soon
            /*/
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
            /*/
        }

        if (!attacker.gameObject.GetComponent<Code_isattacking>().isattacking)
        {
            attack = false;
            if ((this.transform.position.x - player.transform.position.x) > 0)
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
        }
        else
        {
            attack = true;
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
            Debug.DrawLine(CastPoint.position, hit.point, Color.blue);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                playertimer = playerdetectduration;
                foundplayer = true;
                Debug.DrawLine(CastPoint.position, hit.point, Color.red);
            }

            /*/
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Prevhit = hit.collider.gameObject;
                print(Prevhit.name);
                
            }
            if (Prevhit != null && (hit.collider.gameObject != Prevhit))
            {
                print("lostplayer");
                foundplayer = false;
                playerinsight = false;
                playersightTimer -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
                
                if (playersightTimer <= 0f && (!playerinsight) && (!alreadyconfused))
                {
                    foundplayer = false;
                    confusestate = true;
                    print("Confused");
                }
                
            }
            else if (Prevhit != null && (hit.collider.gameObject == Prevhit))
            {
                alreadyconfused = false;
                playersightTimer = sightlostdelay;
                //Debug.DrawLine(CastPoint.position, hit.point, Color.red);
                playerinsight = true;
                foundplayer = true;
                playerinsight = true;
                Debug.DrawLine(CastPoint.position, hit.point, Color.red);
            }/*/
        }
        else
        {
            Debug.DrawLine(CastPoint.position, endPos, Color.blue);
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

    void confusedtime()
    {
        if ((confusedtimer < 0.07) && (confusedtimer > 0.0001))
        {
            confused = false;
        }
    }

    void detecttime()
    {
        if ((playertimer < 0.07) && (playertimer > 0.0001))
        {
            foundplayer = false;
            confused = true;
            confusedtimer = confusedduration;
            this.Rigidbody.velocity = new Vector2(0, 0);
        }
    }

    void animate()
    {
        if (this.Rigidbody.velocity.x > 0)
        {
            run = true;
        }
        else
        {
            run = false;
        }

        animator.SetBool("run", run);
        animator.SetFloat("animation_speed", abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Player_FakeTime);
        animator.SetBool("idle", idle);
        animator.SetBool("attack", attack);
    }
}
