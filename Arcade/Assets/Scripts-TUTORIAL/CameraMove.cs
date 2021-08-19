using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMove : MonoBehaviour
{
    private bool _hasFinished = false;
    private Vector3 _finalPos;
    void Start()
    {
        _finalPos = new Vector3(-5.38999987f, 25f, -5.46000004f);
    }

    
    
    IEnumerator MoveCamera()
    {
        while (transform.position.z > _finalPos.z)
        {
            var tempZ = transform.position.z - (10f*Time.deltaTime);
            transform.position = new Vector3(_finalPos.z,_finalPos.y,tempZ);
            yield return null;
        }

        transform.position = _finalPos;
        _hasFinished = true;
        ChangeScene();
    }

    void ChangeScene()
    {
        if (_hasFinished)
        {
            SceneManager.LoadScene(3); //game
        }
    }
    
    public void StartMovingCamera()
    {
        StartCoroutine(MoveCamera());
    }
}
