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

    private Points po;
    // Start is called before the first frame update
    void Start()
    {
        
        //make sure clone is enabled
        brick.gameObject.SetActive(true);
    }

    public void Initialize()
    {
        po = GameObject.Find("PointsSystem").GetComponent<Points>();
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
                 new Color(59/255f, 124/255f, 181/255f)); 
        }
        if (brickDiff <= 0)
        {
            //make disssapear when braking it.
            Destroy(brick);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("COLLISION IN"+gameObject.name);
        if (other.gameObject.CompareTag("projectile"))

        {
            count=20;
            po.Updatecounter(count);
            brickDiff--;
        }
    }

    
}
