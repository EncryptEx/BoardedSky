using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{   public float initialForce = 20f;
    public Vector3 startPos;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //set start pos
        transform.position = startPos;
        //forces
        rb.AddForce(new Vector3(1f,0f,0.75f)*Time.deltaTime * initialForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}