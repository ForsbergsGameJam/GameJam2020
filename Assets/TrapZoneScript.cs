using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapZoneScript : MonoBehaviour
{
    public int trap_lane = 1;
    public int trap_type = 1;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        trap_lane = random.Next(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0.0f;

        switch (trap_lane)
        {
            case 1: x = -4.0f; break;
            case 2: x = 0.0f; break;
            default: x = 4.0f; break;
        }


        switch (trap_type) {
            case 1:
                Component[] comps = GetComponentsInChildren<Transform>();

                foreach (Component c in comps)
                {
                    if (c.name == "blade")
                    {
                        c.transform.position = new Vector3(x, 0.0f, c.transform.position.z);
                        c.GetComponent<MeshRenderer>().enabled = true;
                    }
                    if (c.parent.name == "Street")
                    {
                    }
                }
                break;


    }
}
