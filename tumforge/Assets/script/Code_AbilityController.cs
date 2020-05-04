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
    public float timeslowduration = 2f;
    public bool timeslowing = false;
    public ParticleSystem PS;
    public float timer;
    public double timer2;
    public float timestop_cooldown = 3f;

    void Start()
    {
        skillcode = Code_staticDataHolder.skillcode;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseScript.GameIsPause)
        {
            print("EEEEEE");
            if (skillcode == 1)
            {
                timeslow();
            }
            else if (skillcode == 2)
            {
                timestop();
            }
        }
    }
    void timestop()
    {
        timer2 -= 0.05;
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && !timestoping && timer <= 0)
        {
            timer2 = timestopduration;
            timestoping = true;
            timer = timestop_cooldown;
        }

        if (timestoping)
        {
            ab_Enemy_FakeTime = 0;
            ab_Player_FakeTime = 0;
            Time.timeScale = 0;
        }
        else
        {
            ab_Enemy_FakeTime = 1;
            ab_Player_FakeTime = 1;
        }

        if (timer2 < 0)
        {
            timer2 = 0;
            timestoping = false;
            timer -= Time.deltaTime;
            Time.timeScale = 1;
        }

        if (timer <= 0)
        {
            timer = 0;
        }
    }

    void timeslow()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (timer > 0)
            {
                timeslowing = !timeslowing;
            }
        }

        if (timeslowing)
        {
            timer -= Time.deltaTime;
            ab_Enemy_FakeTime = ab_TimeslowPercent / 100;
            ab_Player_FakeTime = ab_TimeslowPercent / 100;
            Time.timeScale = ab_TimeslowPercent / 100;
        }
        else
        {
            timer += Time.deltaTime;
            ab_Enemy_FakeTime = 1f;
            ab_Player_FakeTime = 1f;
            Time.timeScale = 1;
        }

        if(timer <= 0)
        {
            timeslowing = false;
        }

        if (timer >= timeslowduration)
        {
            timer = timeslowduration;
        }
    }
}
