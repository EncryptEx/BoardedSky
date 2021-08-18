using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    public TextManager tm;
    private bool _isAbleToDetect = true;
    private void OnTriggerEnter(Collider other)
    {
        if (_isAbleToDetect)
        {
            if (other.gameObject.CompareTag("projectile"))
            {
                _isAbleToDetect = false;
                tm.SetDone();
            }
        }
        
    }
}
