using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayerController : MonoBehaviour
{
    public float lmax = 4f;
    public float rmax = 12f;
    private readonly float smooth = 5.0f;
    private readonly float tiltAngle = 10.0f;
    public float playerSpeed = 20f;
    
    void Update()
    {
        var pos = transform.position;
        //move horizontally with set speed and time control. The rest is as it is.
        var newx = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime + pos.x;
        newx = Mathf.Clamp(newx, lmax, rmax); // limit border values
            
        transform.position = new Vector3(newx, pos.y, pos.z);
        // Smoothly tilts a transform towards a target rotation.
        var tiltAroundY = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        var target = Quaternion.Euler(0, tiltAroundY, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
