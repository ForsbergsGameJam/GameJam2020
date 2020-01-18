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

        GameObject trapZoneCurrent = player.closest_valid_trapzone;

        if (trapZoneCurrent)
        {
            TrapZoneScript trapZone = trapZoneCurrent.GetComponent<TrapZoneScript>();

            if (Input.GetKeyDown(KeyCode.Q) && (trapZone.trap_lane == 1))
            {
                trapZone.trap_lane++;
            }
            if (Input.GetKeyDown(KeyCode.Space) && (trapZone.trap_lane == 2))
            {
                trapZone.trap_lane++;
            }
            if (Input.GetKeyDown(KeyCode.Return) && (trapZone.trap_lane == 3))
            {
                trapZone.trap_lane = 1;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (player.current_lane == 3)
            {
                player.current_lane = 1;
            }
            else player.current_lane++; 
        }
        */


    }

}
