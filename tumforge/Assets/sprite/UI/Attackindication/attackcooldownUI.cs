using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackcooldownUI : MonoBehaviour
{
    GameObject player;
    float attimer;
    float atdelay;
    Animator anim;
    bool full;
    public float currentpos;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        attimer = player.gameObject.GetComponent<Code_playermovement>().A_attacktimer;
        atdelay = player.gameObject.GetComponent<Code_playermovement>().A_attackdelay;

        currentpos = (attimer / atdelay) * -1.6f;
        var pos = parent.gameObject.transform.position;
        pos.x += currentpos;
        transform.position = pos;


        if (attimer == 0)
        {
            full = true;
        }
        else
        {
            full = false;
        }



        anim.SetBool("Full", full);
        //0 max -1.6 min
    }
}
