using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for portal to exit to next level

public class Teleporter_Scene : MonoBehaviour
{
    public string SceneToLoad;
    public string TagList = "Player";
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("player");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (TagList.Contains(TagList))
        {
                Application.LoadLevel(SceneToLoad);
        }
    }
}
