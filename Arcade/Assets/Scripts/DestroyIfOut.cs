using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyIfOut : MonoBehaviour
{
    public GameObject gameOverLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < -23)
        {
            Destroy(this.gameObject);
            gameOverLight.SetActive(true);
            Debug.Log("Game OVER");
        }
    }
}
