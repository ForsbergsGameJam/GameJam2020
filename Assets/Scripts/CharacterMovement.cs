using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float m_Speed;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set the speed of the GameObject
        m_Speed = 10.0f;
       // m_Rigidbody.velocity = transform.forward * m_Speed;
    }

    // Update is called once per frame
    void Update()
    {
         m_Rigidbody.velocity = transform.forward * m_Speed;
    }
}
