using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject closest_valid_trapzone = null;
    public int current_lane = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = 0.0f;

        switch(current_lane)
        {
            case 1: x = -1.5f; break;
            case 2: x = 0.25f; break;
            default: x = 2.5f; break;
        }

        GetComponent<CharacterController>().gameObject.transform.position = new Vector3(x,-0.1f, GetComponent<CharacterController>().gameObject.transform.position.z);

        GetComponent<CharacterController>().transform.Translate(new Vector3(0.0f, 0.0f, 0.03f));

        // Check closest TrapZone
        GameObject[] trapZones = GameObject.FindGameObjectsWithTag("TrapZone");


        Vector3 player_camera_pos = GetComponent<CharacterController>().transform.position;
        //Parera med kamerans position ungefär
        player_camera_pos.z += 0.0f;


        closest_valid_trapzone = null;

        foreach (GameObject trapZone in trapZones)
        {
            if ( (GetComponent<CharacterController>().transform.position.z + 3.0f) > trapZone.transform.position.z)
                continue;

            //if just ground then cannot be valid trapzone
            if (trapZone.GetComponent<TrapZoneScript>().trap_type == 0)
                continue;

            //Debug.Log("player z: "+ GetComponent<CharacterController>().transform.position.z+"   trap zone z: " +trapZone.transform.position.z);
            float dist_to_trapzone = Vector3.Distance(trapZone.transform.position, GetComponent<CharacterController>().transform.position);

            if (closest_valid_trapzone == null)
            {
                closest_valid_trapzone = trapZone;
            }

            float dist_to_closest_trapzone = Vector3.Distance(closest_valid_trapzone.transform.position, player_camera_pos);

            if ( (dist_to_trapzone < dist_to_closest_trapzone )) {
                closest_valid_trapzone = trapZone;
            }
        }

        float required_distance_from_begin_to_player = 15.0f;

        if (closest_valid_trapzone != null && Vector3.Distance(closest_valid_trapzone.transform.position, player_camera_pos) > required_distance_from_begin_to_player) 
            closest_valid_trapzone = null;

        return;
        if (closest_valid_trapzone)
            Debug.LogFormat("Closest TrapZone is " + closest_valid_trapzone.gameObject.name);
        else
            Debug.Log("No closest TrapZone");
    }
}
