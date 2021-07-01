using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMore : MonoBehaviour
{
    public int numberOfBounces = 0;
    public GameObject ball;
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
            var brb = ball.GetComponent<Rigidbody>();
            vel.x = brb.velocity.x;
            vel.x = 0;
            vel.z = (brb.velocity.z * (1+1/3) +1);
            if (vel.z > 63)
            {
                vel.z = 63f;
            }
            brb.velocity = vel;
            Debug.Log("EXTRA FORCE APPLIED"+brb.velocity);
            numberOfBounces += 1;
        }
    }
}
