
using UnityEngine;

public class SaveItForLater : MonoBehaviour
{
    // Start is called before the first frame update
    public SaveItForLater Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}