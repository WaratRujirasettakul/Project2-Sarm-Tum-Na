using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for portal to exit to next level

public class Exit : MonoBehaviour
{
    public string CollisionWithTag;
    public string SceneToLoad;
    public object ColWithThis;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CollisionWithTag.Contains(CollisionWithTag))
        {
                Application.LoadLevel(SceneToLoad);
        }
    }
}
