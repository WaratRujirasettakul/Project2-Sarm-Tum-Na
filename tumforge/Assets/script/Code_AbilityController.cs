using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_AbilityController : MonoBehaviour
{
    public float timestopduration = 10f;
    public int skillcode = 1;
    public bool timestoping = false;
    public float ab_Enemy_FakeTime = 1f;
    public float ab_Player_FakeTime = 1f;
    [Range(0.0f, 100.0f)]
    public float ab_TimeslowPercent = 60f;
    public float timeslowduration = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            /*if(skillcode == 1)
            {
                StartCoroutine(timestop());
            }
            */

            StartCoroutine(timeslow());
        }
    }
    private IEnumerator timestop()
    {
        ab_Enemy_FakeTime = 0f;
        timestoping = true;
        yield return new WaitForSeconds(timestopduration);
        ab_Enemy_FakeTime = 1f;
        timestoping = false;
    }

    private IEnumerator timeslow()
    {
        ab_Enemy_FakeTime = ab_TimeslowPercent/100;
        ab_Player_FakeTime = ab_TimeslowPercent / 100;
        yield return new WaitForSeconds(timeslowduration);
        ab_Enemy_FakeTime = 1f;
        ab_Player_FakeTime = 1f;
    }
}
