using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _finalPos;
    private Vector3 _startPos;
    void Start()
    {
        _startPos = new Vector3(-5.38999987f, 25f, 31.25f);
        _finalPos = new Vector3(-5.38999987f, 24.9799995f, -5.46000004f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
