using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    GameObject player;
    int Dashtime;
    float dashtimer;
    public GameObject image;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");

    }

    // Update is called once per frame
    void Update()
    {
        dashtimer = player.gameObject.GetComponent<Code_playermovement>().D_dashtimer;
        Dashtime = player.gameObject.GetComponent<Code_playermovement>().D_dashnumber;

        if (Dashtime > 0 && dashtimer <= 0)
        {
            image.gameObject.SetActive(true);
        }
        else
        {
            image.gameObject.SetActive(false);
        }
            
    }
}
