using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChanger : MonoBehaviour
{
    public Animator animator;
    public GameObject ForCanvas;

    void Update()
    {

    }

    void Start()
    {
        Time.timeScale = 1f;
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplecte()
    {
        print("FUCKKK");
        PauseScript.GameIsPause = false;
        Time.timeScale = 1f;
        Teleporter.fadeComplete = true;
    }
}
