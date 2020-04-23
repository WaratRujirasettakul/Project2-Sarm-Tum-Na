using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Destructable_by_attack : MonoBehaviour
{
    public GameObject effect;
    //[Header("Sound")]
    //public AudioSource audioSource;
    //public AudioClip Effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attacker")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            //audioSource.PlayOneShot(Effect);
            //AudioSource.PlayClipAtPoint(Effect, transform.position);
            Destroy(gameObject);
        }
    }
}
