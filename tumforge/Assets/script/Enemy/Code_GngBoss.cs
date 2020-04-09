using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_GngBoss : MonoBehaviour
{

    public GameObject spawnpos;
    public GameObject self;
    public GameObject whereToGo;
    public GameObject whereTogetBack;
    public float Delay;
    public float basedelay = 0.8f;
    int Imback = 1;

    public GameObject set11;
    public GameObject set12;
    public GameObject set13;

    public GameObject set21;
    public GameObject set22;
    public GameObject set23;
    public GameObject set24;

    public GameObject set31;
    public GameObject set32;
    public GameObject set33;
    public GameObject set34;
    public GameObject set35;

    public GameObject txt;
    bool set1spawncheck = false;
    bool set2spawncheck = false;
    bool set3spawncheck = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(self.gameObject.GetComponent<Code_BasicEnemybehavior>().e_health <= 10 && self.gameObject.GetComponent<Code_BasicEnemybehavior>().e_health > 8)
        {
            if (!set1spawncheck)
            {
                wheretogo();
                StartCoroutine(set1spawn());
                set1spawncheck = true;
            }
        }

        else if(self.gameObject.GetComponent<Code_BasicEnemybehavior>().e_health <= 6 && self.gameObject.GetComponent<Code_BasicEnemybehavior>().e_health > 4)
        {
            if (!set2spawncheck)
            {
                wheretogo();
                StartCoroutine(set2spawn());
                set2spawncheck = true;
            } 
        }
        
        else if (self.gameObject.GetComponent<Code_BasicEnemybehavior>().e_health <= 4)
        {
            if (!set3spawncheck)
            {
                wheretogo();
                StartCoroutine(set3spawn());
                set3spawncheck = true;
            } 
        }

        Delay -= Time.deltaTime;


        if (set1spawncheck && Imback==1)
        {
            if(set11 == null)
            {
                if(set12 == null)
                {
                    if(set13 == null)
                    {
                        self.transform.position = whereTogetBack.transform.position;
                        Imback = 2;
                    }
                }
            }
        }

        if (set2spawncheck && Imback==2)
        {
            if (set21 == null)
            {
                if (set22 == null)
                {
                    if (set23 == null)
                    {
                        if (set24 == null)
                        {
                            self.transform.position = whereTogetBack.transform.position;
                            Imback = 3;
                        }
                    }
                }
            }
        }

        if (set1spawncheck && Imback==3)
        {
            if (set31 == null)
            {
                if (set32 == null)
                {
                    if (set33 == null)
                    {
                        if (set34 == null)
                        {
                            if (set35 == null)
                            {
                                self.transform.position = whereTogetBack.transform.position;
                                Imback = 4;

                            }
                        }
                    }
                }
            }
        }
    }

    void wheretogo()
    {
        txt.SetActive(true);

            self.transform.position = whereToGo.transform.position;

        
        

        
    }
    
    IEnumerator set1spawn()
    {
        set11.transform.position = spawnpos.transform.position;
        set11.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);
        txt.SetActive(false);
        set12.transform.position = spawnpos.transform.position;
        set12.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);

        set13.transform.position = spawnpos.transform.position;
        set13.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
    }

    IEnumerator set2spawn()
    {
        set21.transform.position = spawnpos.transform.position;
        set21.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);
        txt.SetActive(false);
        set22.transform.position = spawnpos.transform.position;
        set22.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);

        set23.transform.position = spawnpos.transform.position;
        set23.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);

        set24.transform.position = spawnpos.transform.position;
        set24.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
    }

    IEnumerator set3spawn()
    {
        set31.transform.position = spawnpos.transform.position;
        set31.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);
        txt.SetActive(false);
        set32.transform.position = spawnpos.transform.position;
        set32.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);

        set33.transform.position = spawnpos.transform.position;
        set33.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);

        set34.transform.position = spawnpos.transform.position;
        set34.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
        yield return new WaitForSeconds(1f);

        set35.transform.position = spawnpos.transform.position;
        set35.gameObject.GetComponent<Code_BasicEnemybehavior>().foundplayer = true;
    }
}
