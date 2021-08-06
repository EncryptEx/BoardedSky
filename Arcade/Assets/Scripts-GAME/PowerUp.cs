using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [DoNotSerialize] public int power;
    public PlayerController player;
    public Color extraLifeColor;
    public Color extraPointsColor;
    public Color extraPaddleColor;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void SelectColor(int mode)
    {
        switch (mode)
        {
           case 1:
               this.GetComponent<Renderer>().material.color = extraLifeColor;
               power = 1;
               break;
          default:
              var randDecide = UnityEngine.Random.Range(1, 2);
              if (randDecide == 1)
              {
                  this.GetComponent<Renderer>().material.color = extraPointsColor;
                  power = 2;
              }
              else
              {
                 this.GetComponent<Renderer>().material.color = extraPaddleColor;
                 power = 3;
              }
              break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("POWER UP HAS COLLIDE");
        if (other.gameObject.CompareTag("Player"))
        {
            player.UserCollectsPowerUp(this.gameObject);
            Destroy(gameObject);
        }
        
    }
}
