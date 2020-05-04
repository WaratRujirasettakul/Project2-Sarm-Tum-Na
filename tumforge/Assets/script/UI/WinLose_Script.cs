using System.Collections;
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
    public int WhichSceneisthis;

    [Header("Misc")]
    GameObject ingameCursor;
    GameObject player;
    public static bool youWin = false;
    public static bool isRetry = false;
    bool isRetryTime = false;

    void Start()
    {
        Time.timeScale = 1f;
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
        isRetryTime = false;
    }

    void Update()
    {
        if (player == null)
        {
            if (isRetry == false)
            {
                PauseScript.GameIsPause = true;
                Cursor.visible = true;
                ingameCursor.gameObject.SetActive(false);
                loseMenuUI.SetActive(true);
                Time.timeScale = 0.25f;
                isRetryTime = true;
            }
        }
        if (youWin == true)
        {
            if (Code_staticDataHolder.highestLV < WhichSceneisthis)
            {
                Code_staticDataHolder.highestLV = WhichSceneisthis;
                Code_savesystem.SavePlayer(player.GetComponent<Code_playermovement>());
            }
            showContinue();

        }

    }

    //Just a function
    public void showContinue()
    {
        PauseScript.GameIsPause = true;
        Cursor.visible = true;
        Time.timeScale = 0f;
        ingameCursor.gameObject.SetActive(false);
        winMenuUI.SetActive(true);
    }

    //Button
    public void retry()
    {
        Time.timeScale = 1.0f;
        isRetry = true;
        loseMenuUI.SetActive(false);
        ForSceneChanger.GetComponent<SceneChanger>().FadeToLevel();
    }
    public void retry2()
    {
        isRetry = false;
        SceneManager.LoadScene(sceneName);
    }
    public void continueLevel()
    {
        youWin = false;
        PauseScript.GameIsPause = false;
        winMenuUI.SetActive(false);
        //SceneManager.LoadScene(sceneNumber);
        this.GetComponent<LoadingMenuScript>().loadNextLevel();
    }
    public void loadMenu()
    {
        PauseScript.GameIsPause = false;
        winMenuUI.SetActive(false);
        loseMenuUI.SetActive(false);
        ForSceneChanger.GetComponent<SceneChanger>().FadeToLevel();
    }
}
