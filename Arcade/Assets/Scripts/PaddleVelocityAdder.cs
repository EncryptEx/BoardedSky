using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleVelocityAdder : MonoBehaviour
{
    public float m = 1.2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("projectile"))
        {
            Debug.Log("BALL WITH PADDLE");
            var f = other.GetComponent<Rigidbody>();
            var vel = other.GetComponent<Rigidbody>().velocity;
            var force = new Vector3(vel.x*m*0.0005f,0,vel.z*m*0.0005f);
            Debug.Log("applied force: "+force);
            f.AddForce(force);
        }
    }
}
