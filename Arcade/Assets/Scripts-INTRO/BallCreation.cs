using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreation : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBall",0,1.5f);   
    }

    void CreateBall()
    {
        var ballinstance = Instantiate(ball);
        ballinstance.transform.position = this.transform.position;

    }
}
