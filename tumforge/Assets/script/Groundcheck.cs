using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
           // playermovement Playermovement = player.GetComponent<playermovement>();
          //  Playermovement.onground = true;
           // Playermovement.jumplimit = 2;
           // Playermovement.airdashlimit = 2;
        }
    }
}
