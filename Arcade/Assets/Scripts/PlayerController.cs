using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPos;

    public float playerSpeed = 20f;

    public float rmax;

    public float lmax;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        // get actual positon
        Vector3 pos = transform.position;
        //move horizontally with set speed and time control. The rest is as it is.
        float newx = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime + pos.x;
        if (newx > rmax)
        {
            newx = rmax;
        }

        if (newx < lmax)
        {
            newx = lmax;
        }

        
        transform.position = new Vector3(newx, pos.y, pos.z);
    }
}
