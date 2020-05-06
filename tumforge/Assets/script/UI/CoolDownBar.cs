using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    [Header("Slider")]
    public Slider slider;
    public GameObject abilitycon;

    private void Awake()
    {
        abilitycon = GameObject.Find("abilitycon");
    }

    void Update()
    {
        if (Code_staticDataHolder.skillcode == 1)
        {
            slider.value = abilitycon.gameObject.GetComponent<Code_AbilityController>().persent;
        }

        if (Code_staticDataHolder.skillcode == 2)
        {
            slider.value = abilitycon.gameObject.GetComponent<Code_AbilityController>().persent;
        }

    }



}
