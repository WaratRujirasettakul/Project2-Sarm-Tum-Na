using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorlock : MonoBehaviour
{
    
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        pos.z = 10;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
