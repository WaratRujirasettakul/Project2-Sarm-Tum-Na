﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Corruptedmonkattack : MonoBehaviour
{
    public int attackcount = 0;
    public GameObject enemy;
    public GameObject player;
    public GameObject abilitycon;
    public float base_attackdelay = 0.5f;
    float attackdelay;
    public float base_sighttimer = 3f;
    public LayerMask obstacles;
    private GameObject Prevhit;
    public float playersightTimer = 3f;
    public Transform CastPoint;
    public float distance;
    public GameObject bullet;
    public bool isattacking;
    public GameObject isattack;
    bool couroutinerun = false;
    public GameObject aoe;
    public int attacklist = 0;
    public GameObject adam;
    // Start is called before the first frame update
    void Start()
    {
        playersightTimer = base_sighttimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackcount == 1)
        {
            if (attacklist < 2)
            {
                if (playersightTimer <= 0)
                {
                    isattack.gameObject.GetComponent<Code_isattacking>().isattacking = true;
                    print("shoot");
                    if (!couroutinerun)
                    {
                        StartCoroutine(attack());
                    }
                }
            }else
            {
                if (playersightTimer <= 0)
                {
                    isattack.gameObject.GetComponent<Code_isattacking>().isattacking = true;
                    print("shoot");
                    if (!couroutinerun)
                    {
                        StartCoroutine(aoee());
                    }
                }
            }
        }
        playerAttack();
    }
    private void playerAttack()
    {
        float castDist;

        if (enemy.gameObject.GetComponent<Code_Corruptedmonk>().facingright == true)
        {
            castDist = distance;
        }
        else
        {
            castDist = -distance;
        }

        Vector2 endPos = CastPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(CastPoint.position, endPos, obstacles);

        if (hit.collider != null)
        {
            Debug.DrawLine(CastPoint.position, hit.point, Color.green);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Prevhit = hit.collider.gameObject;
                //print(Prevhit.name);
            }
            if (Prevhit != null && (hit.collider.gameObject != Prevhit))
            {
                isattack.gameObject.GetComponent<Code_isattacking>().isattacking = false;
                print("yoo");
                playersightTimer = base_sighttimer;


            }
            else if (Prevhit != null && (hit.collider.gameObject == Prevhit))
            {

                //Debug.DrawLine(CastPoint.position, hit.point, Color.red);
                playersightTimer -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
                if (playersightTimer <= 0f)
                {
                    attackcount = 1;
                }
                else
                {
                    //isattack.gameObject.GetComponent<Code_isattacking>().isattacking = false;
                    attackcount = 0;
                }
                Debug.DrawLine(CastPoint.position, hit.point, Color.red);
            }
        }
        else
        {
            isattack.gameObject.GetComponent<Code_isattacking>().isattacking = false;
            Debug.DrawLine(CastPoint.position, hit.point, Color.green);
        }
    }
    private IEnumerator attack()
    {
        couroutinerun = true;
        yield return new WaitForSeconds(.2f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        Instantiate(bullet, transform.position, Quaternion.identity);
        attackcount = 0;
        attacklist += 1;
        playersightTimer = base_sighttimer;
        couroutinerun = false;
        isattack.gameObject.GetComponent<Code_isattacking>().isattacking = false;
    }
    private IEnumerator aoee()
    {
        couroutinerun = true;
        yield return new WaitForSeconds(.3f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        aoe.SetActive(true);
        yield return new WaitForSeconds(.2f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        adam.SetActive(true);
        yield return new WaitForSeconds(.4f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        aoe.SetActive(false);
        adam.SetActive(false);
        attackcount = 0;
        attacklist = 0;
        playersightTimer = base_sighttimer;
        couroutinerun = false;
        isattack.gameObject.GetComponent<Code_isattacking>().isattacking = false;
    }
}
