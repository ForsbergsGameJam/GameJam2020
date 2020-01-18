using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapZoneScript : MonoBehaviour
{
    public int trap_lane = 1;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        trap_lane = random.Next(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float x = -100.0f;

        switch (trap_lane)
        {
            case 1: x = -4.0f; break;
            case 2: x = 0.0f; break;
            case 3: x = 4.0f; break;
        }

        if(x != -100.0f) {
            Debug.Log("Test");
            gameObject.GetComponentInChildren<Transform>().transform.position = new Vector3(x, 0.0f, gameObject.GetComponentInChildren<Transform>().transform.position.z);
        }
    }
}
