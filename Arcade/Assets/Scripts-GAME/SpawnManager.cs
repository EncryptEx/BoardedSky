using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject proj;

    public GameObject ballPrefab;


    [Tooltip("Force Applied to new ball creation.")]
    public float initialForce;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("EnableBall", 2);
    }

    private void EnableBall()
    {
        proj.SetActive(true);
    }

    public void SpawnDelayedBall()
    {
        Invoke("SpawnNewBall", 3);
    }

    public void SpawnNewBall()
    {
        Debug.Log("Creating a New Ball.");
        var ballInstance = Instantiate(ballPrefab);
        ballInstance.transform.position = new Vector3(-26.72f, 1, 6.2f);
        var rbBallInstance = ballInstance.GetComponent<Rigidbody>();
        rbBallInstance.AddForce(new Vector3(1f, 0f, 0.75f) * Time.deltaTime * initialForce);
    }
}