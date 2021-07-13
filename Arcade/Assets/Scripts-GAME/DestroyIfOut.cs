using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyIfOut : MonoBehaviour
{
    public GameObject gameOverLight;

    public GameOverScript g;
    
    // collision is called once per collision
    
    private void OnTriggerEnter(Collider other)
    {//just only for GAMEOVER.
        if(other.CompareTag("gameover") && gameObject.CompareTag("projectile"))
        {
            Destroy(this.gameObject);
            g.GameOver(gameOverLight);
        }
        else if(other.CompareTag("gameover") && gameObject.name == "Walls")
        {
            Invoke("Remove",5);
        }
        else if (other.CompareTag("gameover")) //this means the objects is falling is not the ball itself (can be player, bricks...)
        {
            Destroy(gameObject);
        }
        
    }

    private void Remove()
    {
        Destroy(gameObject);
    }
}
