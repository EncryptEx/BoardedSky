using UnityEngine;

public class BallCreation : MonoBehaviour
{
    public GameObject ball;

    public float rtime = 1.5f;

    public Vector3 scaleBall = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("CreateBall", 0, rtime);
    }

    private void CreateBall()
    {
        var ballinstance = Instantiate(ball);
        ballinstance.transform.position = transform.position;
        ballinstance.transform.localScale = scaleBall;
    }
}