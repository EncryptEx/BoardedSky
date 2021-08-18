using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroSimulator : MonoBehaviour
{
    public GameObject n1;
    public GameObject n2;

    public GameObject n3;
    public TextManager tm;
    public bool isAbleToNitro = false;
    
    // Start is called before the first frame update
    void Start()
    {
        n1.SetActive(true);
        n2.SetActive(false);
        n3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isAbleToNitro)
        {
            isAbleToNitro = false;
            n1.SetActive(false);
            n2.SetActive(true);
            Invoke("DelayedDisable", 2f);
        }
    }

    void DelayedDisable()
    {
        n2.SetActive(false);
        n3.SetActive(true);
        tm.SetDone();        
    }
}
