using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light LightL;
    public Light LightR;

    public Color collisionColor;
    private Color Light1OriginalColor;

    private Color Light2OriginalColor;
    // Start is called before the first frame update

    private void Start()
    {
        //get color of lights before starting.
        Light1OriginalColor = LightL.color;
        Light2OriginalColor = LightR.color;
    }

//called when collides with a brick.
    public void ChangeLights()
    {
        //do the light animation
        LightL.color = collisionColor;
        LightR.color = collisionColor;
        //reset lights in 0.5 secs
        Invoke("ResetLightColors", 0.5f);
    }

    private void ResetLightColors()
    {
        LightL.color = Light1OriginalColor;
        LightR.color = Light2OriginalColor;
    }
}