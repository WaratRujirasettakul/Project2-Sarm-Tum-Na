using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    public GameObject ForCanvas;

    void Update ()
    {

    }

    void Start()
    {
        Time.timeScale = 1f;
    }
    public void FadeToLevel ()
    {
        Time.timeScale = 1f;
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplecte ()
    {
        PauseScript.GameIsPause = false;
        Time.timeScale = 1f;
        //print(ResponsiveMenu.stage);
        if (LoadingMenuScript.isItLevel == true)
        {
            ForCanvas.GetComponent<LoadingMenuScript>().startToLoad();
        }
        else
        {
            if(LoadingMenuScript.isItLevel == false)
            {
                if(WinLose_Script.isRetry == true)
                {
                    ForCanvas.GetComponent<WinLose_Script>().retry2();
                }
                if (ResponsiveMenu.mapSelectLoad == true)
                {
                    ResponsiveMenu.mapSelectLoad = false;
                    SceneManager.LoadScene(ResponsiveMenu.stage);
                }
                else
                {
                    SceneManager.LoadScene("SC_MainMenuV.2");
                }
            }
        }
    }
}
