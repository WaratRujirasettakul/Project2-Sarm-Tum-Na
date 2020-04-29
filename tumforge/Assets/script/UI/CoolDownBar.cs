using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownBar : MonoBehaviour
{
    [Header("Slider")]
    private Slider slider;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        
    }



}
