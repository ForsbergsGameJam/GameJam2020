﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public GameObject prefab_to_instantiate;
    public GameObject skyscraper_prefab;
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < 250; i++)
		{
			Instantiate(prefab_to_instantiate, new Vector3(0, 0, i * 2.25F), Quaternion.identity);
		}

        for (int i = 0; i < 50; i++)
        {
            Instantiate(skyscraper_prefab, new Vector3(9, 8, i * 10.0F), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
