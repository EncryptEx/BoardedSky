using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    public int lives = 2;

    public GameObject lightcomp;

    [Tooltip("SpawnManager Script")]
    public SpawnManager sm;
    
    [Tooltip("GameOver Script")]
    public GameOverScript go;
    
    public void UserHasLostABall()
    {
        Debug.Log("Action Recieved.");
        if (lives <= 0)
        {
            go.GameOver();
            Debug.Log("PreGameOver");
        }
        else
        {
            lives--;
            Debug.Log("Minus 1 Life");
            //LIVE SUBSTRACTED, NOW NEED TO SPAWN A NEW BALL. 
            sm.SpawnNewBall();
            
            
        }
    }
}
