using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming_cursor : MonoBehaviour
{
    //aiming
    public GameObject CrossHair;
    Vector3 aim;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CrossHairMovement();
       
    }

    private void CrossHairMovement()
    {
        Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
        aim = aim + mouseMovement;
        CrossHair.transform.localPosition = new Vector3(aim.x * 1f, aim.y * 0.5f, -0.1f);
    }
}
