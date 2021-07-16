using System;
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

    //hearts link.
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject Gheart1;
    public GameObject Gheart2;
    public GameObject Gheart3;



    private void Update()
    {
        //display hearts in function of lives var.

        switch (lives)
        {
            case 5: //6 lives, max. 
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(false);
                Gheart1.SetActive(true);
                Gheart2.SetActive(true);
                Gheart3.SetActive(true);
                break;
            case 4: //5 lives
                heart1.SetActive(false);
                heart2.SetActive(false);
                heart3.SetActive(true);
                Gheart1.SetActive(true);
                Gheart2.SetActive(true);
                Gheart3.SetActive(false);
                break;
            case 3: //4 lives
                heart1.SetActive(false);
                heart2.SetActive(true);
                heart3.SetActive(true);
                Gheart1.SetActive(true);
                Gheart2.SetActive(false);
                Gheart3.SetActive(false);
                break;
            case 2: //3 lives.
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                Gheart1.SetActive(false);
                Gheart2.SetActive(false);
                Gheart3.SetActive(false);
                break;
            case 1: // 2 lives
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(false);
                Gheart1.SetActive(false);
                Gheart2.SetActive(false);
                Gheart3.SetActive(false);
                break;
            case 0: //1 live
                heart1.SetActive(true);
                heart2.SetActive(false);
                heart3.SetActive(false);
                Gheart1.SetActive(false);
                Gheart2.SetActive(false);
                Gheart3.SetActive(false);
                break;
        }
    }

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
