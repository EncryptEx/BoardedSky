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
    public Color OneHpColor;
    public int count = 000;

    private Points po;
    // Start is called before the first frame update
    void Start()
    {
        
        //make sure clone is enabled
        brick.gameObject.SetActive(true);
    }
// Update is called once per frame
    void Update()
    {
        ///optimization would be great to earn FPS
        if (brickDiff == 1)
        {
            //future feedback to the user to make him realise has damaged a block
            var brickrenderer = brickbase.GetComponent<Renderer>();
            brickrenderer.material.SetColor("_Color", 
                 OneHpColor); 
        }
        if (brickDiff <= 0)
        {
            //make disssapear when braking it.
            Destroy(brick);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("COLLISION IN"+gameObject.name);
        if (other.gameObject.CompareTag("projectile")) {
            //substact 1 live from brick.
            brickDiff--;
        }
    }

    
}
