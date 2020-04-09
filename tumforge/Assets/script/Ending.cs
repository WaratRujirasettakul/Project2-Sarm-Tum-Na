using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("player");
        if(player == null)
        {
            SceneManager.LoadScene(8);
        }
    }
}
