using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickDiff = 2;
    public GameObject brick;

    public GameObject brickbase;
    public int count = 000;
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
            var brickrenderer = brickbase.GetComponent<Renderer>();
            brickrenderer.material.SetColor("_Color", 
                 Color.grey);
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
            var p = GameObject.Find("PointsSystem").GetComponent<Points>();
            count=20;
            p.Updatecounter(count);
            brickDiff--;
        }
    }
}
