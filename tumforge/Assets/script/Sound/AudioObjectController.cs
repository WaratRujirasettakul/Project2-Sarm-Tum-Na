using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObjectController : MonoBehaviour
{
    public AudioSource shootSound;
    void Start()
    {

    }
    void Update()
    {
        shootEffect();
    }

    void shootEffect()
    {
        if (PauseMenu.GameIsPause == false)
        {
            if (!shootSound.isPlaying)
            {
                shootSound.Play();
            }
        }
        else
        {
            shootSound.Stop();
        }

    }
}
