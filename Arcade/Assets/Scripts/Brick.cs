using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickDiff = 2;
    public GameObject brick;

    public GameObject brickbase;
    // Start is called before the first frame update
    void Start()
    {
        //make sure clone is enabled
        brick.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (brickDiff == 1)
        {
            //future feedback to the user to make him realise has damaged a block.
            //brickbase.color
        }
        if (brickDiff <= 0)
        {
            //make disssapear when braking it.
            Destroy(brick);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION IN"+gameObject.name);
        if (other.CompareTag("projectile"))
            
        {
            brickDiff--;
        }
    }
}
