using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_MeleeEnemyAttacker : MonoBehaviour
{
    public int damage;
    
    public GameObject player;
    public GameObject enemy;
    public GameObject abilitycon;
    public float attackdelay;
    public float base_attackdelay = 0.5f;
    private float time;
    public GameObject isattack;

    
    // Start is called before the first frame update
    void Start()
    {
        
        damage = enemy.GetComponent<Code_BasicEnemybehavior>().e_dam;
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
                isattack.gameObject.GetComponent<Code_isattacking>().isattacking = true;
                player.GetComponent<Code_playermovement>().A_playerhealth -= damage;
            }
            else
            {
                isattack.gameObject.GetComponent<Code_isattacking>().isattacking = false;
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
