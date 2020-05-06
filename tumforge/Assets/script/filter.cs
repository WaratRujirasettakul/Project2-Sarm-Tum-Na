using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class filter : MonoBehaviour
{
    GameObject abilitycon;
    public GameObject stopfilter;
    public GameObject slowfilter;
    // Start is called before the first frame update
    void Start()
    {
        abilitycon = GameObject.Find("abilitycon");
    }

    // Update is called once per frame
    void Update()
    {
        if (abilitycon.GetComponent<Code_AbilityController>().timeslowing)
        {
            slowfilter.SetActive(true);
        }
        else
        {
            slowfilter.SetActive(false);
        }

        if (abilitycon.GetComponent<Code_AbilityController>().timestoping)
        {
            stopfilter.SetActive(true);
        }
        else
        {
            stopfilter.SetActive(false);
        }
    }
}
