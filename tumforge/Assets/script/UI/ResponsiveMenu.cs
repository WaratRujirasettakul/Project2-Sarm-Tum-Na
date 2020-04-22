using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class ResponsiveMenu : MonoBehaviour
{
    Animator CameraObject;
    //Suggestion: Place this code in Main Camera
    [Header("Menus")]
    [Tooltip("The Menu for when the MAIN menu buttons")]
    public GameObject mainMenu;
    [Tooltip("The Menu for when the PLAY button is clicked")]
    public GameObject playMenu;
    [Tooltip("The Menu for when the EXIT button is clicked")]
    public GameObject exitMenu;
    public bool requireAnimator = true;
    public static bool intro = true;
    bool isOption = false;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip onHover;
    public AudioClip onClick;
    public AudioClip Whoosh1;
    public AudioClip Whoosh2;

    private void Update()
    {
        if (intro == true)
        {
            //transform.position = new Vector3(-1930, 1075, -925);
            IntroScene();
        }
    }
    private void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 1;
        if (requireAnimator == true)
        {
            CameraObject = transform.GetComponent<Animator>();
        }
        if (intro == false)
        {
            CameraObject.SetFloat("Scene", 1);
        }
    }
    public void IntroScene()
    {
        if (Input.anyKey)
        {
            audioSource.PlayOneShot(onClick);
            CameraObject.SetFloat("Scene", 1);
            audioSource.PlayOneShot(Whoosh1);
            intro = false;
            Position1();
        }
    }
    public void StartGame()
    {
        playMenu.gameObject.SetActive(true);
        exitMenu.gameObject.SetActive(false);
    }
    public void NewGame()
    {
        //Put something here
        audioSource.PlayOneShot(Whoosh2);
    }
    public void Continue()
    {
        //Put something here
        audioSource.PlayOneShot(Whoosh2);
    }
    public void Confirmation()
    {
        exitMenu.gameObject.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        CameraObject.SetFloat("Scene", 1);
        audioSource.PlayOneShot(Whoosh2);
        isOption = false;
    }
    public void DisableStartButton()
    {
        playMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
    }
    public void Position1()
    {
        DisableStartButton();
        CameraObject.SetFloat("Scene", 1);
        audioSource.PlayOneShot(Whoosh2);
    }
    public void LevelSelect()
    {
        CameraObject.SetFloat("Scene", 4);
        audioSource.PlayOneShot(Whoosh2);
    }
    public void PositionToOptions()
    {
        DisableStartButton();
        CameraObject.SetFloat("Scene", 2);
        audioSource.PlayOneShot(Whoosh2);
        isOption = true;
    }
    public void PositionToCredits()
    {
        DisableStartButton();
        CameraObject.SetFloat("Scene", 3);
        audioSource.PlayOneShot(Whoosh2);
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("SC_MainMenuV.2");

    }
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("SC_MainMenuV.2");
    }
    public void hover()
    {
        audioSource.PlayOneShot(onHover);
    }
    public void click()
    {
        audioSource.PlayOneShot(onClick);
    }




    //[SCENE TO LOAD]
    public void SC_stage1()
    {
        SceneManager.LoadScene("SC_stage1");
    }
    public void SC_stage2()
    {
        SceneManager.LoadScene("SC_stage2");
    }
    public void SC_stage3()
    {
        SceneManager.LoadScene("SC_stage3");
    }
    public void SC_stage4()
    {
        SceneManager.LoadScene("SC_stage4");
    }
    public void SC_stage5()
    {
        SceneManager.LoadScene("SC_stage5");
    }
    public void SC_stage6()
    {
        SceneManager.LoadScene("SC_stage6");
    }
    public void SC_stage7()
    {
        SceneManager.LoadScene("SC_stage7");
    }
    public void SC_stage8()
    {
        SceneManager.LoadScene("SC_stage8");
    }
    public void SC_stage9()
    {
        SceneManager.LoadScene("SC_stage9");
    }
    public void SC_stage10()
    {
        SceneManager.LoadScene("SC_stage10");
    }
    public void SC_stage11()
    {
        SceneManager.LoadScene("SC_stage11");
    }
    public void SC_stage12()
    {
        SceneManager.LoadScene("SC_stage12");
    }
    public void SC_stage13()
    {
        SceneManager.LoadScene("SC_stage13");
    }
    public void redrum()
    {
        SceneManager.LoadScene("SC_RedRoom");
    }
}
