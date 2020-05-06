using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Newgameandcontinue : MonoBehaviour
{
    public Animator CameraObject;
    public AudioSource audioSource;
    public AudioClip Whoosh2;

    public void Continue()
    {
        print("continue");
        PlayerData data = Code_savesystem.loadPlayer();
        Code_staticDataHolder.highestLV = data.level;
        CameraObject.SetFloat("Scene", 4);
        audioSource.PlayOneShot(Whoosh2);
    }
    public void Newgame()
    {
        print("new");
        Code_staticDataHolder.highestLV = 0;
        CameraObject.SetFloat("Scene", 4);
        audioSource.PlayOneShot(Whoosh2);
    }

    public void Cheat()
    {
        Code_staticDataHolder.highestLV = 999999;
        CameraObject.SetFloat("Scene", 4);
        audioSource.PlayOneShot(Whoosh2);
    }


}
