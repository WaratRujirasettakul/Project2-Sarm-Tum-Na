using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResponsiveMenu : MonoBehaviour
{
    Animator CameraObject;

    [Header("Menus")]
    [Tooltip("The Menu for when the MAIN menu buttons")]
    public GameObject mainMenu;
    [Tooltip("The Menu for when the PLAY button is clicked")]
    public GameObject playMenu;
    [Tooltip("The Menu for when the EXIT button is clicked")]
    public GameObject exitMenu;


    private void Start()
    {
        Time.timeScale = 1;
        CameraObject = transform.GetComponent<Animator>();
    }
    public void StartGame()
    {
        playMenu.gameObject.SetActive(true);
        exitMenu.gameObject.SetActive(false);
    }
    public void NewGame()
    {
        //Put something here
    }
    public void Continue()
    {
        //Put something here
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
    }
    public void LevelSelect()
    {
        CameraObject.SetFloat("Scene", 4);
    }
    public void PositionToOptions()
    {
        DisableStartButton();
        CameraObject.SetFloat("Scene", 2);
    }
    public void PositionToCredits()
    {
        DisableStartButton();
        CameraObject.SetFloat("Scene", 3);
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
}
