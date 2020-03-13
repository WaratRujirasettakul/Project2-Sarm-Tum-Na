using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_camfollow : MonoBehaviour
{
    public float xMargin = 1f;
    public float yMargin = 1f;
    public float xSmooth = 8f;
    public float ySmooth = 8f;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;
    //public GameObject Player;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    bool checkXmargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool checkYmargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate()
    {
        Trackplayer();
    }

    void Trackplayer()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (checkXmargin())
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        }

        if (checkYmargin())
        {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    //pubject gameobject player;
    //void Update()
    //{
    //transfor.position = player.position
    //}


}


