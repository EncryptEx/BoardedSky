using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoints : MonoBehaviour
{
    public Points po;
    public Light LightL;
    public Light LightR;
    private Color Light1OriginalColor;
    private Color Light2OriginalColor;
    public int count = 0;

    public Color collisionColor;
    // Start is called before the first frame update
    void Start()
    {
        //get color of lights before starting.
        Light1OriginalColor = LightL.color;
        Light2OriginalColor = LightR.color;
    }
//called when collides with a brick.
  private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("brick"))
        {
            //do the light animation
            LightL.color = collisionColor;
            LightR.color = collisionColor;
            //add 20 to the counter
            count = 20;
            po.Updatecounter(count);
            //reset lights in 0.5 secs
            Invoke("ResetLightColors", 0.5f);
        }
    }

    void ResetLightColors()
    {
        LightL.color = Light1OriginalColor;
        LightR.color = Light2OriginalColor;
    }
}
