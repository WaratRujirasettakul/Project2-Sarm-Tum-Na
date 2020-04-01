using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public string LevelToLoad;
    public string LevelToLoad2;
    public string LevelToLoad3;
    public string LevelToLoad4;
    public string LevelToLoad5;
    public string LevelToLoad6;
    public string LevelToLoad7;
    string menu;

    private void Awake()
    {
        menu = this.name;
    }
    void Start()
    {
        //sound = GetComponent<AudioSource>();
    }
    public void LoadThis()
    {
        //Application.LoadLevel(LevelToLoad);
        SceneManager.LoadScene(LevelToLoad);
        //SceneManager.UnloadSceneAsync(menu);
    }
    public void LoadThis2()
    {
        Application.LoadLevel(LevelToLoad2);
    }
    public void LoadThis3()
    {
        Application.LoadLevel(LevelToLoad3);
    }
    public void LoadThis4()
    {
        Application.LoadLevel(LevelToLoad4);
    }
    public void LoadThis5()
    {
        Application.LoadLevel(LevelToLoad5);
    }
    public void LoadThis6()
    {
        Application.LoadLevel(LevelToLoad6);
    }
    public void LoadThis7()
    {
        Application.LoadLevel(LevelToLoad7);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Option()
    {
        Application.LoadLevel("Option");
    }
    public void setQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}