using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyIfOut : MonoBehaviour
{
    //public GameObject gameOverLight;

    public GameOverScript g;
    [Tooltip("LivesManager Script ( Lives System) ")]
    public LivesManager lm;

    private void Start()
    {
        g = GameObject.Find("GameOverSystem").GetComponent<GameOverScript>();
        lm = GameObject.Find("LivesSystem").GetComponent<LivesManager>();
    }


    // collision is called once per collision
    private void OnTriggerEnter(Collider other)
    {
        //just only for GAMEOVER.
        if (other.CompareTag("gameover") && gameObject.CompareTag("projectile"))
        {
            Destroy(this.gameObject);
            // not game over, just substract 1 from lives var.
            //g.GameOver();

            lm.UserHasLostABall();
            Debug.Log("User Has Lost a Ball");
        }
    }
}
