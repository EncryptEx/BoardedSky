using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _finalPos;
    void Start()
    {
        _finalPos = new Vector3(-5.38999987f, 25f, -5.46000004f);
    }

    IEnumerator MoveCamera()
    {
        while (transform.position.z < _finalPos.z)
        {
            transform.position = new Vector3(_finalPos.z,_finalPos.y,transform.position.z-(0.1f*Time.deltaTime));
            yield return null;
        }

        transform.position = _finalPos;
    }

    public void StartMovingCamera()
    {
        StartCoroutine(MoveCamera());
    }
}
