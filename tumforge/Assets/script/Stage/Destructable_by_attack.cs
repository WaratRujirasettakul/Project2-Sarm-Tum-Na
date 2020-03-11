using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable_by_attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attacker")
        {
            Destroy(gameObject);
        }
    }
}
