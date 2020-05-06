using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_levelcheck : MonoBehaviour
{
    public int unlockwhenlv;
    int nowlv;
    public GameObject Xcross;

    // Update is called once per frame
    void Update()
    {
        nowlv = Code_staticDataHolder.highestLV;

        if (unlockwhenlv <= nowlv)
        {
            Xcross.SetActive(false);
        }
        else
        {
            Xcross.SetActive(true);
        }
    }
}
