﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public Rigidbody rb;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0,0,100);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -100);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(100, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-100, 0, 0);
        }
    }
}
