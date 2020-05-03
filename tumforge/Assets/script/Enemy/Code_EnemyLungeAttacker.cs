using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_EnemyLungeAttacker : MonoBehaviour
{
    
    public int attackcount = 0;
    public GameObject enemy;
    public GameObject abilitycon;
    public float base_attackdelay = 0.5f;
    public LayerMask obstacles;
    private GameObject Prevhit;
    public float playersightTimer = 3f;
    public Transform CastPoint;
    public float distance;
    bool cou = false;
    public GameObject abox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        playerAttack();
        if (attackcount == 1)
        {
            if (!cou)
            {
                cou = true;
                StartCoroutine(lungatk());
            }
        }


    }
    private void playerAttack()
    {
        float castDist;

        if (enemy.gameObject.GetComponent<Code_StrongEnemyBehavior>().facingright == true)
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
                print("yoo");
                playersightTimer = base_attackdelay;

            }
            else if (Prevhit != null && (hit.collider.gameObject == Prevhit))
            {
                
                //Debug.DrawLine(CastPoint.position, hit.point, Color.red);
                playersightTimer -= Time.deltaTime * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
                if (playersightTimer <= 0f)
                {
                    attackcount = 1;
                }
                Debug.DrawLine(CastPoint.position, hit.point, Color.red);
            }
        }
        else
        {
            Debug.DrawLine(CastPoint.position, hit.point, Color.green);
        }
    }

    IEnumerator lungatk()
    {
        abox.SetActive(true);
        yield return new WaitForSeconds(.2f * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime);
        abox.SetActive(false);
        cou = false;
    }
    }



