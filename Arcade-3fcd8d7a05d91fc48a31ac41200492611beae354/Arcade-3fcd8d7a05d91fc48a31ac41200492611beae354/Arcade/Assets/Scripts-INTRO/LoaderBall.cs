using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderBall : MonoBehaviour
{
    // Start is called before the first frame update
    public float m = 60f; //initial force
    public float rest = 60f; //diff btw x and z
    void Start()
    {
        
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(m-rest,0,m));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
