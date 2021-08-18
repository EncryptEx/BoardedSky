using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviourTutorial : MonoBehaviour
{
    public int brickDiff;
    public GameObject brickbase;
    public Color OneHpColor;

    private void Update()
    {
        switch (brickDiff)
        {
            case 0:
                gameObject.SetActive(false);
                Invoke("ReAppear",2);
                break;
            case 1:
                var brickrenderer = brickbase.GetComponent<Renderer>();
                brickrenderer.material.SetColor("_Color",
                    OneHpColor);
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            brickDiff--;
        }
    }

    void ReAppear()
    {
        gameObject.SetActive(true);
    }
    
}
