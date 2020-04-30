using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_swordmandmg : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    private int damage;
    public float basedelay;
    public float curdelay;
    // Start is called before the first frame update
    void Start()
    {
        damage = enemy.GetComponent<Code_Swordmanbehav>().e_dam;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("suck");
            player.GetComponent<Code_playermovement>().A_playerhealth -= damage;

        }
    }
}
