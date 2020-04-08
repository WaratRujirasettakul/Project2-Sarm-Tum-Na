using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] camera;
    private int numberOfCamera;
    public static bool disabled = false;
    void Start()
    {
        camera = new GameObject[numberOfCamera];

        for (int i = 0; i < numberOfCamera; i++)
        {
            // Create, place in the world, and set name.
            camera[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            camera[i].transform.position = new Vector3(0.0f, -1.5f * i, 0.0f);
            camera[i].name = i.ToString();

            // The first GameObject is the top parent, so ignore it for now.
            if (i > 0)
            {
                camera[i].transform.parent = camera[i - 1].transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
        {
            camera[numberOfCamera].SetActive(false);
            camera[numberOfCamera+1].SetActive(true);
        }
        else
        {
            camera[numberOfCamera].SetActive(true);
            camera[numberOfCamera+1].SetActive(false);
        }
    }

    void camUpdate()
    {

    }
}
