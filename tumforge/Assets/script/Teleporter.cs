using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    //public GameObject entrance;
    public GameObject destination;
    //public string TagList = "player";
    GameObject player;
    GameObject background;
    GameObject camera;
    GameObject FloorChanger;
    public static bool floorChange = false;
    public static bool fadeComplete = false;


    private void Start()
    {
        player = GameObject.Find("player");
        //background = GameObject.Find("blackground");
        //camera = GameObject.Find("mainCamera");
        camera = GameObject.FindWithTag("MainCamera");
        background = GameObject.FindWithTag("MainCamera");
        FloorChanger = GameObject.Find("BlackFade02");
        fadeComplete = false;

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.position = destination.transform.position;
            background.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, background.transform.position.z);
            camera.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, camera.transform.position.z);
            FloorChanger.GetComponent<SceneChanger>().FadeToLevel();
        }
       
    }
    public void Update()
    {
        if (fadeComplete == true)
        {
            player.transform.position = destination.transform.position;
            background.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, background.transform.position.z);
            camera.transform.position = new Vector3(destination.transform.position.x, destination.transform.position.y, camera.transform.position.z);
            //fadeComplete = false;
        }
    }




}