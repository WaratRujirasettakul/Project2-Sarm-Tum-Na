using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDead : MonoBehaviour
{
    GameObject thisIsPlayer;

    void Start()
    {
        thisIsPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(thisIsPlayer);
        }
    }
}
