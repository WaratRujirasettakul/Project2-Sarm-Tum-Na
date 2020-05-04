using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skillselect : MonoBehaviour
{
    public Toggle timeSlowButton;
    public Toggle timeStopButton;
    void Start()
    {
        //Code_staticDataHolder.skillcode = 1;
        
    }
    void Update()
    {
        if (Code_staticDataHolder.skillcode == 1)
        {
            timeSlowButton.Select();
        }
        else
        {
            timeStopButton.Select();
        }
    }
    public void timestop()
    {
        Code_staticDataHolder.skillcode = 2;
    }
    public void timeslow()
    {
        Code_staticDataHolder.skillcode = 1;
    }


}
