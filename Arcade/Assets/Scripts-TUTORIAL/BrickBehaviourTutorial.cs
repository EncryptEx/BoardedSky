using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviourTutorial : MonoBehaviour
{
    private bool _hasDied = false;
    public int brickDiff;
    public GameObject brickbase;
    public Color OneHpColor;
    private Color _initialColor;

    private void Start()
    {
        _initialColor = OneHpColor;
    }

    private void Update()
    {
        var brickrenderer = brickbase.GetComponent<Renderer>();
        if (!_hasDied)
        {
            switch (brickDiff)
            {
                case 0:
                    _hasDied = true;
                    gameObject.SetActive(false);
                    Invoke("ReAppear", 6);
                    break;
                case 1:
                    brickrenderer.material.SetColor("_Color",
                        OneHpColor);
                    break;
                case 2:
                    _initialColor = brickrenderer.material.color;
                    break;

            }
        }
        else
        {
            if (_initialColor != OneHpColor) //determine if the brick had been in 2 lifes mode.
            {
                brickrenderer.material.SetColor("_Color",
                    _initialColor); //reset the color as original (part of reapear)
            }
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
