using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_swordmanatkcheck : MonoBehaviour
{

    public int attackcount = 0;
    public GameObject abilitycon;
    public GameObject attackbox;
    public bool attacking = false;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if(attackcount == 1)
        {
            if (!attacking)
            {
                attacking = true;
                StartCoroutine(attack());
            }
            
        }
    }

    private IEnumerator attack()
    {
        Physics2D.IgnoreLayerCollision(12, 10, true);
        yield return new WaitForSeconds(0.2f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        attackbox.SetActive(true);
        yield return new WaitForSeconds(0.1f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        attackbox.SetActive(false);
        yield return new WaitForSeconds(0.5f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        Physics2D.IgnoreLayerCollision(12, 10, false);
        attackcount = 0;
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && (attackcount == 0))
        {
            attackcount = 1;
        }
    }
}
