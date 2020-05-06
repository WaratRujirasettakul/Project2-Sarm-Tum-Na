using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Bulletcode : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
     GameObject player;
    Vector2 direction;
     GameObject abilitycon;
    public GameObject shot;
    public GameObject clank;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("player");
        abilitycon = GameObject.Find("abilitycon");
        rb = GetComponent<Rigidbody2D>();
        direction = (player.transform.position - transform.position).normalized * speed * abilitycon.gameObject.GetComponent<Code_AbilityController>().ab_Enemy_FakeTime;
        rb.velocity = new Vector2(direction.x, direction.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            clank.SetActive(true);
            print("hit");
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            player.gameObject.GetComponent<Code_playermovement>().A_playerhealth -= 1;
        }
    }
}
