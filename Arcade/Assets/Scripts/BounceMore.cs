using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMore : MonoBehaviour
{
    public Rigidbody brb;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       // if (other.CompareTag("projectile"))
        if (other.CompareTag("projectile"))
        {
            
            vel.x = brb.velocity.x;
            vel.x = 0;
            vel.z = (brb.velocity.z / 2) + (brb.velocity.z / 3);
            brb.velocity = vel;
            Debug.Log("EXTRA FORCE APPLIED"+brb.velocity);
        }
    }
}
