using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerScript player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        if (!player) return;
        Debug.Log("TJOHO");
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (player.current_lane == 3)
            {
                player.current_lane = 1;
            }
            else player.current_lane++; 
        }

        if (Input.GetKeyDown(KeyCode.Q) && (player.current_lane % 3) == 1)
        {
            Debug.Log("P1 pressed while in lane 1");
        }
        if (Input.GetKeyDown(KeyCode.Space) && (player.current_lane % 3) == 2)
        {
            Debug.Log("P2 pressed while in lane 2");
        }
        if (Input.GetKeyDown(KeyCode.Return) && (player.current_lane % 3) == 0)
        {
            Debug.Log("P3 pressed while in lane 3");
        }
    }

}
