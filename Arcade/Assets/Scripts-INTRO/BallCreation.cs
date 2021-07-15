using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreation : MonoBehaviour
{
    public GameObject ball;

    public float rtime = 1.5f;

    public Vector3 scaleBall = new Vector3(1, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBall",0,rtime);   
    }

    void CreateBall()
    {
        var ballinstance = Instantiate(ball);
        ballinstance.transform.position = this.transform.position;
        ballinstance.transform.localScale = scaleBall;

    }
}
