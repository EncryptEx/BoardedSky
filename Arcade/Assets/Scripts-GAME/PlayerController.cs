using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 startPos;
    public GameOverScript go;
    public float initialPSValue = 20f;
    public float playerSpeed = 20f;

    public float rmax;

    public float lmax;
    private readonly float smooth = 5.0f;
    private readonly float tiltAngle = 10.0f;

    public NitroManager nm;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = startPos;
        playerSpeed = initialPSValue;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!go.gameover)
        {
            //check if wants nitro
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // check if nitro is available
                if (nm.isNitroAvailable)
                {
                    playerSpeed += 10f;
                    nm.DisableNitro();
                    Invoke("ResetPlayerSpeed",2);
                }
            }
            
            
            // get actual positon
            var pos = transform.position;
            //move horizontally with set speed and time control. The rest is as it is.
            var newx = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime + pos.x;
            if (newx > rmax) newx = rmax;

            if (newx < lmax) newx = lmax;

            transform.position = new Vector3(newx, pos.y, pos.z);
            // Smoothly tilts a transform towards a target rotation.
            var tiltAroundY = Input.GetAxis("Vertical") * tiltAngle;

            // Rotate the cube by converting the angles into a quaternion.
            var target = Quaternion.Euler(0, tiltAroundY, 0);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
    }

    void ResetPlayerSpeed()
    {
        playerSpeed = initialPSValue;
    }


    public void UserCollectsPowerUp(GameObject powerUp)
    {
        //is a power up
        //detect its power
        Debug.Log("USER Has recieved action from power up");
        var power = powerUp.gameObject.GetComponent<PowerUp>().power;
        switch (power)
        {
            case 1:
                //extraLife

                break;

            case 2:
                //extraPoints

                break;

            case 3:
                //extraPaddle
                float saveLastPaddleValue = transform.localScale.x;
                //this.transform.localScale.Set(6, transform.localScale.y, transform.localScale.z);
                Debug.Log(transform.localScale + "   " + transform.localScale.x);
                break;

        }
    }
}