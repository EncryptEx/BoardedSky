using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
