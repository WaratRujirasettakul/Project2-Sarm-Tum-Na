using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Finalboss : MonoBehaviour
{
    bool facingright = true;
    public GameObject player;
    public Rigidbody2D Rigidbody;
    public GameObject abilitycon;
    public GameObject CastPoint;
    public int e_health = 1;
    public LayerMask obstacles;
    RaycastHit2D hit;
    public int detect_distance;
    public float playertimer;
    public float playerdetectduration;
    public bool foundplayer;
    public float movementspeed;
    int count = 0;
    bool cou = false;

    bool afraid = false;
    bool run = false;
    bool die = false;
    bool idle = true;
    bool trigger = false;
    bool dead = false;
    public Animator animator;
    [Header("Effect")]
    public GameObject effectWhenDestroyed;
    // Start is called before the first frame update
    private void Start()
    {
        Flip();        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!dead)
        {
            playerdetector(detect_distance);
            if (foundplayer)
            {
                trigger = true;
            }
            if (trigger)
            {
                runaway();
            }
        }
        animate();


    }
    private void runaway()
    {
        

        if(count == 0 && !cou)
        {
            cou = true;
            StartCoroutine(Afraid());
        }else if(count == 2)
        {
            run = true;
            if ((this.transform.position.x - player.transform.position.x) > 0)
            {

                //player left
                if (facingright)
                {

                    Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
                }
                else
                {
                    Flip();
                    Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
                }
            }
            else
            {
                //player right
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
        }
        
    }
    private IEnumerator Afraid()
    {
        idle = false;
        afraid = true;
        yield return new WaitForSeconds(0.5f);
        afraid = false;
        count = 2;
    }
    private void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
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

        Vector2 endPos = CastPoint.gameObject.transform.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(CastPoint.gameObject.transform.position, endPos, obstacles);

        if (hit.collider != null)
        {
            Debug.DrawLine(CastPoint.gameObject.transform.position, hit.point, Color.blue);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                if(count == 2)
                {
                    Flip();
                }
                else {
                    playertimer = playerdetectduration;
                    foundplayer = true;
                    Debug.DrawLine(CastPoint.gameObject.transform.position, hit.point, Color.red);
                }
                
            } else if (hit.collider.gameObject.CompareTag("Wall"))
            {
                Flip();
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
            Debug.DrawLine(CastPoint.gameObject.transform.position, endPos, Color.blue);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attacker")
        {
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        dead = true;
        run = false;
        die = true;
        yield return new WaitForSeconds(0.2f);
        Instantiate(effectWhenDestroyed, transform.position, Quaternion.identity);
        Destroy(gameObject);
        print("attacked");
        print(e_health);
        print(player.gameObject.GetComponent<Code_playermovement>().A_playerdam);
    }
    void animate()
    {
        animator.SetBool("run", run);
        animator.SetBool("afraid", afraid);
        animator.SetBool("die", die);
        animator.SetFloat("animation_speed", abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        animator.SetBool("idle", idle);
        
    }
}
