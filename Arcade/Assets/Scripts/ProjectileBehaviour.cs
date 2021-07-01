using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{   public float initialForce = -200f;
    public float random = 50f;
    public Vector3 startPos;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //set start pos
        transform.position = startPos;
        //rotate and move
        rb.AddForce(new Vector3(random,0f,initialForce));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
