using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public AudioClip[] stepClips;
    public AudioSource player;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        player = GetComponent<AudioSource>();
    }

    public void step() {
        player.clip = stepClips[Random.Range(0, stepClips.Length)];
        player.PlayOneShot(player.clip);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
