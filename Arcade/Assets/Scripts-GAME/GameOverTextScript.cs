using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTextScript : MonoBehaviour
{
    
    public GameOverScript g;

    public GameOverTextScript Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (g.gameover && SceneManager.GetActiveScene().name == "Game")
        {
            if (GetComponent<RectTransform>().position.z <= -1.9)
            {
                Destroy(GetComponent<Rigidbody>());
                SceneManager.LoadScene(2);
                
            }
        }

        
    }
}