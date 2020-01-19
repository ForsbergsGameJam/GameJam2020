using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapZoneScript : MonoBehaviour
{
    public int trap_type = 0;
    public int trap_lane = 1;
    static private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        trap_lane = random.Next(1, 3);
        Debug.Log("trap lane "+trap_lane);

        int random_val = random.Next(1, 100);

        if (random_val < 40)
        {
            trap_type = random.Next(2) + 1;
        }
        else
            trap_type = 0;

        //trap_type = 2;
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0.0f;

        switch (trap_lane)
        {
            case 1: x = -1.5f; break;
            case 2: x = 0.5f; break;
            default: x = 2.5f; break;
        }


        Component[] comps = GetComponentsInChildren<Component>();

        //Initially hide everything
        foreach (Component c in comps)
        {
            if(c.GetComponent<MeshRenderer>())
            c.GetComponent<MeshRenderer>().enabled = false;
        }

            switch (trap_type) {
            //Plain Ground
            case 0:
                foreach (Component c in comps)
                {
                    if (c.name == "s1" || c.name == "s2" || c.name == "s3" || c.name == "s4")
                    {
                        c.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                break;
            //Blade
            case 1:
                foreach (Component c in comps)
                {
                    foreach (MeshRenderer mr in c.GetComponentsInChildren<MeshRenderer>())
                    {
                        mr.enabled = false;
                    }

                    //Render blade
                    if (c.name == "blade")
                    {
                        c.transform.position = new Vector3(x, 0.9f, c.transform.position.z);
                        c.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (c.name == "s1" || c.name == "s2" || c.name == "s3" || c.name == "s4")
                    {
                        c.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            break;
            //Hole
            case 2:
                foreach (Component c in comps)
                {
                    //Render street broken
                    if(c.name == "sb1")
                    {
                        c.GetComponent<MeshRenderer>().enabled = true;
                    }
                    else if (c.name == "sb2")
                    {
                        c.GetComponent<MeshRenderer>().enabled = true;
                        c.transform.position = new Vector3(x, -0.8f, c.transform.position.z);
                    }
                    else if ( c.name == "s4")
                    {
                        c.GetComponent<MeshRenderer>().enabled = true;
                    }
                }
                break;

        }
    }
}
