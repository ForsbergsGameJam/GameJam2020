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
        float x = -100.0f;

        switch(current_lane)
        {
            case 1: x = -4.0f; break;
            case 2: x = 0.0f; break;
            case 3: x = 4.0f; break;
        }

        if(x!= -100.0f)
            GetComponent<CharacterController>().gameObject.transform.position = new Vector3(x,0.0f, GetComponent<CharacterController>().gameObject.transform.position.z);

        GetComponent<CharacterController>().transform.Translate(new Vector3(0.0f, 0.0f, 0.2f));

        // Check closest TrapZone
        GameObject[] trapZones = GameObject.FindGameObjectsWithTag("TrapZone");


        Vector3 player_camera_pos = GetComponent<CharacterController>().transform.position;
        //Parera med kamerans position ungefär
        player_camera_pos.z += 0.0f;


        closest_valid_trapzone = null;

        foreach (GameObject trapZone in trapZones)
        {
            if (GetComponent<CharacterController>().transform.position.z > trapZone.transform.position.z)
                continue;

            Debug.Log("player z: "+ GetComponent<CharacterController>().transform.position.z+"   trap zone z: " +trapZone.transform.position.z);
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

        if (closest_valid_trapzone != null && Vector3.Distance(closest_valid_trapzone.transform.position, player_camera_pos) > 20.0f )
            closest_valid_trapzone = null;

        if (closest_valid_trapzone)
            Debug.LogFormat("Closest TrapZone is " + closest_valid_trapzone.gameObject.name);
        else
            Debug.Log("No closest TrapZone");
    }
}
