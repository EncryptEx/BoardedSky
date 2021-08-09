using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float initialForce = 20f;
    public Vector3 startPos;
    private Rigidbody rb;


    private Vector3 prevPos;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //set start pos
        transform.position = startPos;
        //forces
        rb.AddForce(new Vector3(1f, 0f, 0.75f) * initialForce);
        
        prevPos = Vector3.zero;
        InvokeRepeating("StallPrevention", 5f, 1f);
    }

    private void StallPrevention()
    {

        //main checking
        if ( Mathf.Abs(prevPos.y - transform.position.y) < .3f ) // check if ball is stuck
        {
            rb.AddForce(new Vector3(Random.value, 0f, Random.value) * initialForce/2f); // generate a random force.
            AudioManager.Instance.PlayNitro();
        }
        prevPos = transform.position;
    }


    public void IncreaseBallSpeed(float multiplier)
    {
        rb.velocity = rb.velocity * multiplier;
    }
}