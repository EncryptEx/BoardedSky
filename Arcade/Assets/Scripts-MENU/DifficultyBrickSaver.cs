using UnityEngine;

public class DifficultyBrickSaver : MonoBehaviour
{
    public DifficultyBrickSaver Instance;

    public float diff = 3;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (diff == 3f) // actual non possible difficulty just to make sure player can set difficulty. 
            diff = 2;
    }
}