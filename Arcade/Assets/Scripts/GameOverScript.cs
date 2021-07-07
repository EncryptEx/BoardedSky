using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public bool gameover = false;
    public GameObject GameOverText;
    public GameObject walls;
    public GameObject player;

    private void Start()
    {
        gameover = false; //always!
    }

    public void GameOver(GameObject gameOverLight)
    {
        gameover = true;
        gameOverLight.SetActive(true);
        //operacion brick down
        var bricks = GameObject.FindGameObjectsWithTag("brick");
        foreach (var brick in bricks)
        {
            brick.gameObject.AddComponent<Rigidbody>();
        }
        walls.gameObject.AddComponent<Rigidbody>();
        player.gameObject.AddComponent<Rigidbody>();
        var alt = GameOverText.gameObject.GetComponent<RectTransform>().position.y;

        /*while (GameOverText.gameObject.GetComponent<RectTransform>().position.y >= -90)
        {
            alt -= 10f*Time.deltaTime;*/
            alt = 410; 
            var v = new Vector3(GameOverText.gameObject.GetComponent<RectTransform>().position.x, alt, GameOverText.gameObject.GetComponent<RectTransform>().position.z);
            Debug.Log(v);
            GameOverText.gameObject.GetComponent<RectTransform>().position = v;
        //}
        
        //just for debug
        Debug.Log("Game OVER");
    }
}
