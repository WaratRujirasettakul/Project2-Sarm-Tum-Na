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
    public GameObject[] enemys;
    bool enemyalldie = false;
    bool hitteleporter;
    int nullnumber;

    void Start()
    {
        //player = GameObject.Find("player");
        player = GameObject.FindGameObjectWithTag("Player");
        //WinLose_Script function = Canvas.GetComponent<WinLose_Script>();
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (TagList.Contains(TagList) && activatable)
        {
            hitteleporter = true;
            nullnumber = 0;
            for (int i = 0; i < enemys.Length; i++)
            {
                if (enemys[i] == null)
                {
                    nullnumber += 1;
                }
            }

            if (nullnumber == enemys.Length)
            {
                enemyalldie = true;
            }
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        hitteleporter = false;
    }

    public void Update()
    {
        if (hitteleporter && enemyalldie)
        {
            activatable = false;
            WinLose_Script.youWin = true;
        }
    }
}
