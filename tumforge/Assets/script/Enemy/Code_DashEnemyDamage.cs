using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_DashEnemyDamage : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject attacker;
    public int damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print(damage);
            if (attacker.GetComponent<Code_EnemyLungeAttacker>().attackcount == 1)
            {
                player.GetComponent<Code_playermovement>().A_playerhealth -= damage;
                
            }

        }
    }
}
