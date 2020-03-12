using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // " " is for X-Axis, "2" is for Y-Axis

    private float length, startpos;
    public GameObject cam; //usually Using camara as an object
    public float horizontalParallaxEffect;

    public float verticalParallaxEffect;
    private float length2, startpos2;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        startpos2 = transform.position.y;
        length2 = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - horizontalParallaxEffect));
        float dist = (cam.transform.position.x * horizontalParallaxEffect);
        //-----------------------------------
        float temp2 = (cam.transform.position.y * (1 - verticalParallaxEffect));
        float dist2 = (cam.transform.position.y * verticalParallaxEffect);

        //transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        transform.position = new Vector3(startpos + dist, startpos2 + dist2, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
        //-------------------------------
        if (temp2 > startpos2 + length2)
        {
            startpos2 += length2;
        }
        else if (temp2 < startpos2 - length2)
        {
            startpos2 -= length2;
        }


    }
}
