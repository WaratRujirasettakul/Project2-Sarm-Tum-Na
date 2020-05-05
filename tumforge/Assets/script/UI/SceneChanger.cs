using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    public GameObject ForCanvas;


    void Start()
    {
        Time.timeScale = 1f;
    }
    public void FadeToLevel ()
    {
        print(Time.timeScale);
        Time.timeScale = 1f;
        print(Time.timeScale);
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplecte ()
    {
        print(Time.timeScale);
        PauseScript.GameIsPause = false;
        //print(ResponsiveMenu.stage);
        if (LoadingMenuScript.isItLevel == true)
        {
            ForCanvas.GetComponent<LoadingMenuScript>().startToLoad();
        }
        else
        {
                if (WinLose_Script.isRetry == true)
                {
                    ForCanvas.GetComponent<WinLose_Script>().retry2();
                }
                else
                {
                    if (ResponsiveMenu.mapSelectLoad == true)
                    {
                        ResponsiveMenu.mapSelectLoad = false;
                        SceneManager.LoadScene(ResponsiveMenu.stage);
                    }
                    else
                    {
                    if (ResponsiveMenu.TrainingArea == true)
                    {
                        ResponsiveMenu.TrainingArea = false;
                        SceneManager.LoadScene("SC_Training_Area");
                    }
                    else
                    {
                        SceneManager.LoadScene("SC_MainMenuV.2");
                    }
                    }
                }
            
        }
             
    }
}
