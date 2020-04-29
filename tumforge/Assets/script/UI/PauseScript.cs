using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPause = false;  //*****IMPORTANT! PLEASE STATE THIS IN EVERY ACTIONS OF OTHER SCRIPT*****
    GameObject ingameCursor;
    [Header("Canvas")]
    public GameObject pauseMenuUI;
    public GameObject menuPause;
    public GameObject Options;
    [Header("Sound")]
    public AudioSource audioSource;
    public AudioSource MusicSource;
    public AudioClip onHover;
    public AudioClip onClick;
    public AudioClip onPause;

    GameObject player;
    void Start()
    {
        player = GameObject.Find("player");
        Time.timeScale = 1.0f;
        ingameCursor = GameObject.Find("cursor");
        pauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (player != null)
            {
                if (GameIsPause == true)
                {
                    mainPauseMenu();

                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void mainPauseMenu()
    {
        menuPause.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
    }
    public void options()
    {
        menuPause.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
    }
    public void Resume()
    {
        MusicSource.UnPause();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ingameCursor.gameObject.SetActive(true);
    }
    void Pause()
    {
        MusicSource.Pause();
        audioSource.PlayOneShot(onPause);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ingameCursor.gameObject.SetActive(false);
    }
    public void hover()
    {
        audioSource.PlayOneShot(onHover);
    }
    public void click()
    {
        audioSource.PlayOneShot(onClick);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("SC_MainMenuV.2");
    }
}
