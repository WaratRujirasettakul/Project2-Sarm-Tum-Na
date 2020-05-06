using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storytxt : MonoBehaviour
{
    public GameObject txt;
    bool cou = false;
    public GameObject abilitycon;
    public GameObject thiss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!cou)
            {
                cou = true;
                StartCoroutine(Txtdis());
            }
        }
    }

    private IEnumerator Txtdis()
    {
        cou = true;
        txt.SetActive(true);
        yield return new WaitForSeconds(2f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        txt.SetActive(false);
        cou = false;
        thiss.SetActive(false);
    }
}
