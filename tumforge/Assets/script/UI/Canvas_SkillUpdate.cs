using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas_SkillUpdate : MonoBehaviour
{
    public GameObject timeSlowButton;
    public GameObject timeStopButton;
    Scene current_Scene;
    string currentSceneName;
    void Start()
    {
        current_Scene = SceneManager.GetActiveScene();
        currentSceneName = current_Scene.name;
    }

    void Update()
    {
        if (currentSceneName != "SC_MainMenuV.2")
        {
            if (Code_staticDataHolder.skillcode == 1)
            {
                timeSlowButton.SetActive(true);
                timeStopButton.SetActive(false);
            }
            else if (Code_staticDataHolder.skillcode == 2)
            {
                timeSlowButton.SetActive(false);
                timeStopButton.SetActive(true);
            }
        }
    }
}
