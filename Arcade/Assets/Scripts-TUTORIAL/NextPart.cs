using UnityEngine;

public class NextPart : MonoBehaviour
{
    public bool isAbleToSkip;
    public TextManager tm;
    void Start()
    {
        isAbleToSkip = false;
    }
    
    void Update()
    {
        if (isAbleToSkip)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                tm.StartPart2();
                isAbleToSkip = false;
                this.gameObject.SetActive(false);
            }
        }
    }
}
