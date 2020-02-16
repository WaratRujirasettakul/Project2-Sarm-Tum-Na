using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_Crosshair : MonoBehaviour
{
    //aiming
    public GameObject CrossHair;
    Vector3 aim;
    public GameObject player;

    private Vector3 Aimpoint;
    public float rotationz;
    public Vector2 direction;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        
    }

    void Update()
    {
        CrossHairMovement();
    }

    private void CrossHairMovement()
    {

        //Vector3 mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), -0.0f);
        //aim = aim + mouseMovement;
        //CrossHair.transform.localPosition = new Vector3(aim.x * 1f, aim.y * 0.5f, -0.1f);
        Aimpoint = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        CrossHair.transform.position = new Vector2(Aimpoint.x, Aimpoint.y);
        Vector3 difference = Aimpoint - player.transform.position;
        rotationz = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        float distance = difference.magnitude;
        direction = difference / distance;
        direction.Normalize();
       
    }
}
