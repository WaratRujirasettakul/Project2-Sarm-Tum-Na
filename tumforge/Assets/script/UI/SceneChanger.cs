using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    public GameObject ForCanvas;
    void Update ()
    {

    }

    public void FadeToLevel ()
    {
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplecte ()
    {
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
                else
                {
                    SceneManager.LoadScene("SC_MainMenuV.2");
                }
            }
        }
    }
}
