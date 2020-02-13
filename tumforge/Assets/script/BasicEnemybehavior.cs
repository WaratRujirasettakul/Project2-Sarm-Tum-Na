using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemybehavior : MonoBehaviour
{
    public int flipcheck;
    public int health = 1;
    public Transform origin;
    private Vector2 direction = new Vector2(1,0);
    public float movementspeed = 20;
    public float losRange = 50;
    private int behavior = 0;
    public float actiondelay = 2f;
    public GameObject meflip;
    

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        actiondelay -= 1*Time.deltaTime;
        print(actiondelay);
        if(actiondelay <= 1)
        {
            behavior = Random.Range(0, 10);
            print(behavior);
            if(behavior == 1)
            {
                flip();
                actiondelay = 4f;
            }else if (behavior == 2)
            {
                StartCoroutine(EnemMovement());
                actiondelay = 4f;
            }
            else
            {
                //idle
                actiondelay = 2f;
            }
        }
        if (flipcheck > 0)
        {
            direction = new Vector2(-1, 0);
        }else if (flipcheck < 0)
        {
            direction = new Vector2(1, 0);
        }

        RaycastHit2D Check = Physics2D.Raycast(origin.position, direction, losRange);
        //if(Check.collider != null)
        //{
        //    if(Check.collider.gameObject.GetComponent<player>() != null)//i got the eror here pls fix
        //    {
        //        followup();
        //    }
        //    else
        //    {

        //    }
        //}
    }
    private IEnumerator EnemMovement()
    {

        rb.velocity = new Vector2(movementspeed, rb.velocity.y);
        yield return new WaitForSeconds(1.5f);
    }
    public void followup()
    {
        Debug.Log("player detected");
        //please make it follow player if you can
    }
    public void attack()
    {
        //just leave this blank
    }
    public void flip()
    {
        Vector3 theScale = meflip.transform.localScale;
        theScale.x *= -1;
        meflip.transform.localScale = theScale;
        flipcheck *= -1;
    }
    
}
