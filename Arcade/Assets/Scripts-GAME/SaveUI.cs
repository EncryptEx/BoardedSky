using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveUI : MonoBehaviour
{
    // Start is called before the first frame update
    public SaveUI Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}