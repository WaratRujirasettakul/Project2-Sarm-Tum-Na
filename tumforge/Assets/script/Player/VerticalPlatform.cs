using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if(Input.GetAxisRaw("Vertical") == -1)
        {

        }
    }
}
//Get axis vertical. Hold = -1 sec,open timer 0.5, else reset timer, If timer = pass = release the player down.