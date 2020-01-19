using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource[] all_sfx;
    public AudioSource sfx;
 

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        StartCoroutine(WaitF());
    }

    IEnumerator WaitF()
    {
        yield return new WaitForSeconds(Random.Range(2,8));
        all_sfx[Random.Range(0, 2)].Play();
        StartCoroutine(WaitF());
    }
}
