using UnityEngine;

public class DestroyIfOut : MonoBehaviour
{
    [Tooltip("LivesManager Script ( Lives System) ")]
    public LivesManager lm;

    private void Start()
    {
        lm = GameObject.Find("LivesSystem").GetComponent<LivesManager>();
    }


    // collision is called once per collision
    private void OnTriggerEnter(Collider other)
    {
        //just only for GAMEOVER.
        if (other.CompareTag("gameover") && gameObject.CompareTag("projectile"))
        {
            Destroy(gameObject);
            // not game over, just substract 1 from lives var.
            //g.GameOver();

            lm.UserHasLostABall();
            Debug.Log("User Has Lost a Ball");
        }
    }
}