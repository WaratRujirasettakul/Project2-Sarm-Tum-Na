using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticle : MonoBehaviour
{
    public GameObject parentObject;
    void Start()
    {
        parentObject = GameObject.Find("Trap_Laser");
        this.transform.SetParent(parentObject.transform);
    }

}
