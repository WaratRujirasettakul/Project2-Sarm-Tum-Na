using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Code_Dialogsystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typespeed;
    public GameObject click;
    public GameObject abilitycon;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        abilitycon.GetComponent<Code_AbilityController>().ab_Player_FakeTime = 0;
        abilitycon.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime = 0;
        StartCoroutine(type());
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            if (Input.GetMouseButtonDown(0))
            {
                nextsentences();
                if (index == sentences.Length-1)
                {
                    canvas.SetActive(false);
                    
                    abilitycon.GetComponent<Code_AbilityController>().ab_Player_FakeTime = 1;
                    abilitycon.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime = 1;
                }
            }
            click.SetActive(true);
            
        }
        
    }

    IEnumerator type()
    {
        
        foreach (char letter in sentences[index].ToCharArray())
        {
            click.SetActive(false);
            textDisplay.text += letter;
            yield return new WaitForSeconds(typespeed);
            
        }
    }

    public void nextsentences()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(type());
        }
        
    }
}
