using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    GameObject player;
    void Update()
    {
        player = GameObject.Find("player");
        if(player == null)
        {
            //SceneManager.LoadScene("SC_PlaceHolder_Lose");
        }
    }
}
