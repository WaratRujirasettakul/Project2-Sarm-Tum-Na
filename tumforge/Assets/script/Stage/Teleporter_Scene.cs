using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for portal to exit to next level

public class Teleporter_Scene : MonoBehaviour
{
    //public string SceneToLoad;
    public string TagList = "Player";
    GameObject player;

    GameObject Canvas;
    GameObject function;
    WinLose_Script showContinue;
    bool activatable = true;
    void Start()
    {
        //player = GameObject.Find("player");
        player = GameObject.FindGameObjectWithTag("Player");
        //WinLose_Script function = Canvas.GetComponent<WinLose_Script>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (TagList.Contains(TagList))
        {
            //Application.LoadLevel(SceneToLoad);
            if (activatable == true)
            {
                activatable = false;
                WinLose_Script.youWin = true;
            }
        }
        //if (collision.gameObject.tag == "Player")
        //{
            //showContinue.showContinue();
            //WinLose_Script.youWin = true;
        //}
    }
}
