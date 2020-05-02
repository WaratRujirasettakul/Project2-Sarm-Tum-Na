﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose_Script : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject winMenuUI;
    public GameObject loseMenuUI;
    public GameObject ForSceneChanger;

    [Header("Sound")]
    AudioSource audioSource;
    AudioSource MusicSource;
    AudioClip onHover;
    AudioClip onClick;
    AudioClip onPause;

    [Header("Scene")]
    Scene current_Scene;
    string sceneName;
    public int sceneNumber;

    [Header("Misc")]
    GameObject ingameCursor;
    GameObject player;
    public static bool youWin = false;
    public static bool isRetry = false;

    void Start()
    {
        audioSource = gameObject.GetComponent<PauseScript>().audioSource;
        MusicSource = gameObject.GetComponent<PauseScript>().MusicSource;
        onHover = gameObject.GetComponent<PauseScript>().onHover;
        onClick = gameObject.GetComponent<PauseScript>().onClick;
        onPause = gameObject.GetComponent<PauseScript>().onPause;

        player = GameObject.Find("player");
        ingameCursor = GameObject.Find("cursor");
        winMenuUI.SetActive(false);
        loseMenuUI.SetActive(false);

        current_Scene = SceneManager.GetActiveScene();
        sceneName = current_Scene.name;
        sceneNumber = current_Scene.buildIndex + 1;

        youWin = false;
        isRetry = false;
    }

    void Update()
    {
        if (player == null)
        {
            Cursor.visible = true;
            Time.timeScale = 0.25f;
            ingameCursor.gameObject.SetActive(false);
            loseMenuUI.SetActive(true);
        }
        if (youWin == true)
        {
            showContinue();
        }

    }

    //Just a function
    public void showContinue()
    {
        Cursor.visible = true;
        Time.timeScale = 0.0f;
        ingameCursor.gameObject.SetActive(false);
        winMenuUI.SetActive(true);
        youWin = false;
    }

    //Button
    public void retry()
    {
        isRetry = true;
        ForSceneChanger.GetComponent<SceneChanger>().FadeToLevel();
    }
    public void retry2()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void continueLevel()
    {
        winMenuUI.SetActive(false);
        //SceneManager.LoadScene(sceneNumber);
        this.GetComponent<LoadingMenuScript>().loadNextLevel();
    }
}
