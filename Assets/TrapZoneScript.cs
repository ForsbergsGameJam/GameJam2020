using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapZoneScript : MonoBehaviour
{
    public int trap_type = 0;
    public int trap_lane = 1;
    static private System.Random random = new System.Random();
    public static int generated_zones = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (generated_zones < 5) {  // 8
            trap_type = 0;
            generated_zones++;
            return;
        }

        trap_lane = random.Next(1, 3);


        if (random.Next(1, 100) < 60)
        {
            trap_type = random.Next(2) + 1;
        }
        else
            trap_type = 0;

        //trap_type = 2; //REMOVE
        generated_zones++;
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


        Transform[] comps = GetComponentsInChildren<Transform>();
        
        //Initially hide everything
        foreach (Transform c in comps)
        {
            //Debug.Log("components: "+c.name);
            c.gameObject.SetActive(false);
        }
        gameObject.SetActive(true);

        //Debug.Log("gameObject: " + gameObject.name);
        switch (trap_type) {
            //Plain Ground
            case 0:
                foreach (Transform c in comps)
                {
                    if (c.gameObject.name == "s1" || c.gameObject.name == "s2" || c.gameObject.name == "s3" || c.gameObject.name == "s4" || c.gameObject.name == "Street")
                    {
                        c.gameObject.SetActive(true);
                    }
                }
                break;
            //Blade
            case 1:
                foreach (Transform c in comps)
                {

                    if (c.gameObject.name == "Blade")
                    {
                        c.gameObject.SetActive(true);
                    }

                    //Render blade
                    if (c.gameObject.name == "blade")
                    {
                        c.transform.position = new Vector3(x, 0.9f, c.transform.position.z);
                        c.gameObject.SetActive(true);
                    }
                    else if (c.gameObject.name == "s1" || c.gameObject.name == "s2" || c.gameObject.name == "s3" || c.gameObject.name == "s4" || c.gameObject.name == "Street")
                    {
                        c.gameObject.SetActive(true);
                    }
                }
            break;
            //Hole
            case 2:
                foreach (Transform c in comps)
                {
                    //Render street broken
                    if (c.gameObject.name == "StreetBroken")
                    {
                        c.gameObject.SetActive(true);
                    }

                    if (c.gameObject.name == "sb1")
                    {
                        c.gameObject.SetActive(true);;
                    }
                    else if (c.gameObject.name == "sb2")
                    {
                        c.gameObject.SetActive(true);
                        c.transform.position = new Vector3(x, -0.8f, c.transform.position.z);
                    }
                    else if ( c.gameObject.name == "s4" || c.gameObject.name == "Street")
                    {
                        c.gameObject.SetActive(true);
                    }
                }
                break;

        }
    }
}
