using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code_AbilityController : MonoBehaviour
{
    public float timestopduration = 10f;
    public GameObject enemtime;
    public int skillcode = 1;
    public float ab_Enemy_FakeTime = 1f;
    public float ab_Player_FakeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(skillcode == 1)
            {
                StartCoroutine(timestop());
            }
            
        }
    }
    private IEnumerator timestop()
    {
        ab_Enemy_FakeTime = 0f;
        yield return new WaitForSeconds(timestopduration);
        ab_Enemy_FakeTime = 1f;
    }
}
