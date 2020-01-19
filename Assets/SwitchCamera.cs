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

        if(ts.Seconds >= 8 /*standard value: 8*/) //Drop the beat at 8 seconds in
        {
            GetComponent<Camera>().enabled = false;
        }
    }
}
