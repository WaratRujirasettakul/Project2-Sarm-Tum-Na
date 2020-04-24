using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public int damage = 2;
    //public GameObject enemy;
    //public string TagList = "player";
    GameObject player;
    public GameObject effect;
    private void Awake()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        //effect.transform.SetParent(parentObject.transform);
        //effect.transform.parent = parentObject.transform;
    }
    private void Start()
    {
        player = GameObject.Find("player");
        //damage = enemy.GetComponent<Code_BasicEnemybehavior>().e_dam;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Code_playermovement>().A_playerhealth -= damage;
        }
    }
}
