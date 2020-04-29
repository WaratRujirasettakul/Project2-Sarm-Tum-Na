using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMenuScript : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject loadingUI;

    [Header("Scene")]
    Scene current_Scene;
    string currentSceneName;
    int nextSceneNumber;

    void Start()
    {
        current_Scene = SceneManager.GetActiveScene();
        currentSceneName = current_Scene.name;
        nextSceneNumber = gameObject.GetComponent<WinLose_Script>().sceneNumber;
            //current_Scene.buildIndex + 1;
    }










    public void continueLevel()
    {
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneNumber);

        while (!operation.isDone == false)
        {
            Debug.Log (operation.progress);

            yield return null;
        }
    }
}