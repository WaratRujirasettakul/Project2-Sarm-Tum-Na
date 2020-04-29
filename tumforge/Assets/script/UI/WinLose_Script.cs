using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose_Script : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject winMenuUI;
    public GameObject loseMenuUI;
    GameObject ingameCursor;

    [Header("Sound")]
    GameObject canvasToGetAudioSource;
    AudioSource audioSource;
    AudioSource MusicSource;
    AudioClip onHover;
    AudioClip onClick;
    AudioClip onPause;


    void Start()
    {
        //canvasToGetAudioSource = GameObject.Find("Canvas");
        //canvasToGetAudioSource.GetComponent<PauseScript>().audioSource;
        //audioSource = canvasToGetAudioSource<"audioSource">();
        audioSource = gameObject.GetComponent<PauseScript>().audioSource;
        MusicSource = gameObject.GetComponent<PauseScript>().MusicSource;
        onHover = gameObject.GetComponent<PauseScript>().onHover;

        ingameCursor = GameObject.Find("cursor");
        winMenuUI.SetActive(false);
        loseMenuUI.SetActive(false);
    }
}
