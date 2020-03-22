using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTimer;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if(Input.GetAxisRaw("Vertical") == 1)
        {
            waitTimer = 0.5f;
        }
        if(Input.GetAxisRaw("Vertical") == -1)
        {
            if(waitTimer <=0)
            {
                effector.rotationalOffset = 180f;
                waitTimer = 0.5f;

            }
            else
            {
                waitTimer -= Time.deltaTime;
            }
        }

        if (Input.GetButton("Jump"))
        {
            effector.rotationalOffset = 0; 
        }
    }
}
//Get axis vertical. Hold = -1 sec,open timer 0.5, else reset timer, If timer = pass = release the player down.