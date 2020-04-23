using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_LaserPlatform : MonoBehaviour
{
    private bool moving;
    private Vector3 velocity;
    public float dirX, moveSpeed;
    bool moveRight = true;
    bool moveUp = true;
    public float rightXPosition;
    public float leftXPosition;
    public float topYPosition;
    public float bottomYPosition;
    public bool vertical = false;
    public bool horizontal = false;

    void Update()
    {
        if (transform.position.x > rightXPosition)
            moveRight = false;
        if (transform.position.x < leftXPosition)
            moveRight = true;
        if (transform.position.y > topYPosition)
            moveUp = false;
        if (transform.position.y < bottomYPosition)
            moveUp = true;

        if( horizontal == true)
        {
              if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
              else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        
        if(vertical == true)
        {
              if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
              else
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //moving = true;
            // collision.collider.transform.SetParent(transform);
            //GetComponent<Rigidbody2D>().isKinematic = true;
            //transform.parent = collision.transform;
            //print("JESUS");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // collision.collider.transform.SetParent(null);
            //GetComponent<Rigidbody2D>().isKinematic = false;
            //transform.parent = null;
            //moving = false;
            //print("GOD");
        }
    }

    private void FixedUpdate()
    {
        if (moving == true)
        {
            transform.position += (velocity * Time.deltaTime);
        }
    }
}

