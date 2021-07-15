using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSystem : MonoBehaviour
{
    public BricksBuilding bb;
    public LivesManager lm;
    private void Start()
    {
        bb = GameObject.Find("SpawnBricks").GetComponent<BricksBuilding>();
    }

    public void CheckForExistingBricks()
    {
        Debug.Log("Checking if aren't bricks,");
        if (GameObject.FindGameObjectsWithTag("brick").Length == 1) //why 1? bc the checking is done before removing the last one
        {
            Debug.Log("No bricks!");
            //need to regenerate new blocks until player dies

            //delayed!!! important to make sure ball doesn't gets shoked. (can happen)
            bb.GenerateDelayedNewBricks();
            //add life to player as a reward 
            lm.lives++;

        }
    }
}
