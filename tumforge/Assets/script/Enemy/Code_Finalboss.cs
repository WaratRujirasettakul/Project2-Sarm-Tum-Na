using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Finalboss : MonoBehaviour
{
    public bool facingright = true;
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
    public GameObject doosh;
    public GameObject noo;
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
            
        }

        if (run)
        {
            if (facingright)
            {
                Rigidbody.velocity = new Vector2(movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
            }
            else
            {
                Rigidbody.velocity = new Vector2(-movementspeed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime, Rigidbody.velocity.y); // optimize needed
            }
        }
        
    }
    private void LateUpdate()
    {
        animate();
    }
    private IEnumerator Afraid()
    {
        run = false;
        idle = false;
        afraid = true;
        doosh.SetActive(true);
        yield return new WaitForSeconds(0.5f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        afraid = false;
        doosh.SetActive(false);
        yield return new WaitForSeconds(0.1f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        run = true;
        Flip();
        cou = false;

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
            if(hit.collider.gameObject.CompareTag("Player"))
                {
                print("Prayat");
                if (!cou)
                {
                    cou = true;
                    StartCoroutine(Afraid());
                }
            }else if (hit.collider.gameObject.CompareTag("Wall"))
            {
                print("Prayut");
                if (!cou)
                {
                    cou = true;
                    StartCoroutine(Afraid());
                }
            }

            /*Debug.DrawLine(CastPoint.gameObject.transform.position, hit.point, Color.blue);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                print("count:"+count);
                if(count == 2)
                {
                    Flip();
                    playertimer = playerdetectduration;
                    foundplayer = true;
                }
                else if (count == 1)
                {
                    count = 2;
                    playertimer = playerdetectduration;
                    foundplayer = true;
                    Debug.DrawLine(CastPoint.gameObject.transform.position, hit.point, Color.red);
                }
                else
                {
                    playertimer = playerdetectduration;
                    foundplayer = true;
                    Debug.DrawLine(CastPoint.gameObject.transform.position, hit.point, Color.red);
                }
                
            } else if (hit.collider.gameObject.CompareTag("Wall"))
            {
                count = 1;
            }

            
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
        afraid = false;
        die = true;
        noo.SetActive(true);
        yield return new WaitForSeconds(1f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
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
