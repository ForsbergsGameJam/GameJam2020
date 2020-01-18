using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CharacterController>().transform.Translate(new Vector3(0.0f, 0.0f, 0.2f));

        // Check closest TrapZone
        GameObject[] trapZones = GameObject.FindGameObjectsWithTag("TrapZone");

        foreach (GameObject trapZone in trapZones)
        {
            if (GetComponent<CharacterController>().transform.position.z < trapZone.transform.position.z)
            {

            }
        }

    }
}
