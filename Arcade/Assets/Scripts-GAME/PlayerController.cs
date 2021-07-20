
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPos;
    public GameOverScript go;
    public float playerSpeed = 20f;

    public float rmax;

    public float lmax;
    float smooth = 5.0f;
    float tiltAngle = 10.0f;

   
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!go.gameover)
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
            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundY = Input.GetAxis("Vertical") * tiltAngle;

            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        }
    }
}
