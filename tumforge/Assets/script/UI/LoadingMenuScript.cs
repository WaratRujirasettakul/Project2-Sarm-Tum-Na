using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingMenuScript : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject loadingUI;

    [Header("Scene")]
    Scene current_Scene;
    string currentSceneName;
    int nextSceneNumber;
    public GameObject ForSceneChanger;
    public static bool isItLevel;

    void Start()
    {
        Time.timeScale = 1f;
        isItLevel = false;
        current_Scene = SceneManager.GetActiveScene();
        currentSceneName = current_Scene.name;
        nextSceneNumber = current_Scene.buildIndex + 1;
        loadingUI.SetActive(false);
        if (nextSceneNumber == 17)
        {
            nextSceneNumber = 0;
        }
    }


    public void loadNextLevel()
    {
        Time.timeScale = 1.0f;
        isItLevel = true;
        ForSceneChanger.GetComponent<SceneChanger>().FadeToLevel();
        //loadingUI.SetActive(true);
    }
    public void startToLoad()
    {
        isItLevel = false;
        StartCoroutine(LoadAsynchronously());
    }
    IEnumerator LoadAsynchronously()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneNumber);
        //operation.allowSceneActivation = false;

        while (!operation.isDone == false)
        {
            //float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //loadingBar.value = progress; =====We doesn't have any loading bar so I didn't use this
            Debug.Log(operation.progress);
            yield return null;
            //operation.allowSceneActivation = true;
        }
        //yield return null;
    }

}
