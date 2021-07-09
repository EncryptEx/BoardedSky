using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(true);
        InvokeRepeating("Blink",1f,0.5f);
    }

    private int c = 0;
    void Blink()
    {
        if (text.gameObject.activeSelf && c >= 4)
        {
            text.gameObject.SetActive(false);
            c = 0;
        }
        else
        {
            c++;
            text.gameObject.SetActive(true);
        }
    }
}
