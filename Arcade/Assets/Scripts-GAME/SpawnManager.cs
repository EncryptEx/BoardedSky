using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject proj;
    // Start is called before the first frame update
    void Start()
    {
       Invoke("EnableBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableBall()
    {
        proj.SetActive(true);
    }
}
