using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyBrickSaver : MonoBehaviour
{
    public DifficultyBrickSaver Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    
    public float diff = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (diff == 3f) // actual non possible difficulty just to make sure player can set difficulty. 
        {
            diff = 2;
        }
    }
}
