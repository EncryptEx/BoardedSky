using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameOverTextScript : MonoBehaviour
{
    public GameOverScript g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (g.gameover)
        {
            if (GetComponent<RectTransform>().position.z <= -1.9)
            {
                Destroy(GetComponent<Rigidbody>());
            }
        }
    }
}
