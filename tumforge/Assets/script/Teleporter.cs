using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    //public GameObject entrance;
    public GameObject destination;
    public string TagList = "Player";
    public GameObject player;



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    // if (TagList.Contains(TagList))
    // {
    //player's postion = tp out x location + 10
    //print("hit");
    //player.transform.position = destination.transform.position;
    // if (Input.GetKey(KeyCode.E) == true)
    //{
    //player.transform.position = destination.transform.position;
    // }
    // }
    // }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (TagList.Contains(TagList))
        {
            //player's postion = tp out x location + 10

            //print("hit");

            //player.transform.position = destination.transform.position;
            if (Input.GetKeyUp(KeyCode.E) == true)
            {
                player.transform.position = destination.transform.position;
                print("JESUS");
            }
        }
       

    }




}