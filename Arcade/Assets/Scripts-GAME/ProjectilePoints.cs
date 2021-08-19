using UnityEngine;

//SCRIPT TO CHANGE BACKGROUND LIGHTNING WHEN COLLIDING
public class ProjectilePoints : MonoBehaviour
{
    public Points po;
    public LightManager lightManager;
    public int count;
    private WinSystem b;

    private void Start()
    {
        //get component via script for future prefabs. :(
        lightManager = GameObject.Find("Background").GetComponent<LightManager>();
        po = GameObject.Find("PointsSystem").GetComponent<Points>();
        b = GameObject.Find("WinSystem").GetComponent<WinSystem>();
    }

    //called when collides with a brick.
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("brick"))
        {
            lightManager.ChangeLights();
            count = 20;
            po.Updatecounter(count);
            // check for exisitng bricks.
            b.CheckForExistingBricks();
        }
    }
}