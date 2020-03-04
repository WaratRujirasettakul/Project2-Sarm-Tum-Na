using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_EnemyLungeAttacker : MonoBehaviour
{
    
    public int attackcount = 0;
    public GameObject player;
    public GameObject enemy;
    public GameObject abilitycon;
    public float attackdelay;
    public float base_attackdelay = 0.5f;
    private float time;


    // Start is called before the first frame update
    void Start()
    {

        
        attackdelay = base_attackdelay;
    }

    // Update is called once per frame
    void Update()
    {




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            attackdelay = base_attackdelay;
        }
        if (collision.gameObject.tag == "Wall")
        {
            //enemy.gameObject.GetComponent<Code_BasicEnemybehavior>().wallcol = true;
            //enemy.gameObject.GetComponent<Code_BasicEnemybehavior>().movementspeed = enemy.gameObject.GetComponent<Code_BasicEnemybehavior>().basemovespeed;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attackdelay -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
            if (attackdelay <= 0)
            {
                attackcount = 1;
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            attackdelay = base_attackdelay;
        }
        if (collision.gameObject.tag == "Wall")
        {
            //enemy.gameObject.GetComponent<Code_BasicEnemybehavior>().wallcol = false;
            //enemy.gameObject.GetComponent<Code_BasicEnemybehavior>().movementspeed = enemy.gameObject.GetComponent<Code_BasicEnemybehavior>().basemovespeed;
        }
    }


}
