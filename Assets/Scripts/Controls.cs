using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int lane;
    // Start is called before the first frame update
    void Start()
    {
        lane = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (lane == 3)
            {
                lane = 1;
            }
            else lane++; 
        }

        if (Input.GetKeyDown(KeyCode.Q) && (lane%3) == 1)
        {
            Debug.Log("P1 pressed while in lane 1");
        }
        if (Input.GetKeyDown(KeyCode.Space) && (lane%3) == 2)
        {
            Debug.Log("P2 pressed while in lane 2");
        }
        if (Input.GetKeyDown(KeyCode.Return) && (lane%3) == 0)
        {
            Debug.Log("P3 pressed while in lane 3");
        }
    }

}
