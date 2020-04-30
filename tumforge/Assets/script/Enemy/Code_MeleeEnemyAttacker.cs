using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_MeleeEnemyAttacker : MonoBehaviour
{
    public int damage;
    
    public GameObject player;
    public GameObject enemy;
    public GameObject abilitycon;
    public float attackdelay;
    public float base_attackdelay = 0.5f;
    private float time;
    public GameObject isattack;
    bool cou = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        damage = enemy.GetComponent<Code_BasicEnemybehavior>().e_dam;
        attackdelay = base_attackdelay;
    }

    // Update is called once per frame
    void Update()
    {
        
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

            attackdelay = base_attackdelay;

       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            attackdelay -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
            if (!cou)
            {
                if (attackdelay <= 0)
                {
                    StartCoroutine(atk());
                    cou = true;
                }
            }
            
        }
        else
        {
            attackdelay = base_attackdelay;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

            attackdelay = base_attackdelay;

      
    }

    private IEnumerator atk()
    {
        isattack.gameObject.GetComponent<Code_isattacking>().isattacking = true;
        
        yield return new WaitForSeconds(.7f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        player.GetComponent<Code_playermovement>().A_playerhealth -= damage;
        isattack.gameObject.GetComponent<Code_isattacking>().isattacking = false;
        cou = false;
    }
}
