using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    Stopwatch stopWatch = new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        stopWatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = stopWatch.Elapsed;

        UnityEngine.Debug.Log(ts.Seconds);
        if(ts.Seconds >= 8) //Drop the beat at 8 seconds in
        {
            GetComponent<Camera>().enabled = false;
        }
    }
}
