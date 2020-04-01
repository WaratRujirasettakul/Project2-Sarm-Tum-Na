using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundControlV2 : MonoBehaviour
{
    public string SFX;
    public bool stopScene = true;
    public string SceneToStop;
    public string SceneToStop2;
    public string SceneToStop3;
    public string SceneToStop4;
    public string SceneToStop5;
    public string SceneToStop6;
    public string SceneToStop7;
    public string SceneToStop8;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");  //FindGameObjectsWithTag("Music");
            if (objs.Length > 1)
                Destroy(this.gameObject);

            //UnityEngine.Object.DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        
    }

    void Update()
    {
        if (stopScene = true)
        {
            if (SceneManager.GetActiveScene().name == SceneToStop)
            {
                Destroy(GameObject.Find(SFX));
            }
            if (SceneManager.GetActiveScene().name == SceneToStop2)
            {
                Destroy(GameObject.Find(SFX));
            }
            if (SceneManager.GetActiveScene().name == SceneToStop3)
            {
                Destroy(GameObject.Find(SFX));
            }
            if (SceneManager.GetActiveScene().name == SceneToStop4)
            {
                Destroy(GameObject.Find(SFX));
            }
            if (SceneManager.GetActiveScene().name == SceneToStop5)
            {
                Destroy(GameObject.Find(SFX));
            }
            if (SceneManager.GetActiveScene().name == SceneToStop6)
            {
                Destroy(GameObject.Find(SFX));
            }
            if (SceneManager.GetActiveScene().name == SceneToStop7)
            {
                Destroy(GameObject.Find(SFX));
            }
            if (SceneManager.GetActiveScene().name == SceneToStop8)
            {
                Destroy(GameObject.Find(SFX));
            }
        }
        
    }
}
