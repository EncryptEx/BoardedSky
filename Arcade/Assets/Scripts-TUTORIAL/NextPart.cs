using UnityEngine;

public class NextPart : MonoBehaviour
{
    private bool _isPartOne = true;
    public bool isAbleToSkip;
    public TextManager tm;
    void Start()
    {
        isAbleToSkip = false;
    }
    
    void Update()
    {
        if (isAbleToSkip && _isPartOne)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                tm.StartPart2();
                isAbleToSkip = false;
                this.gameObject.SetActive(false);
                _isPartOne = false;
            }
        }

        if (isAbleToSkip && !_isPartOne) // end of tutorial
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                //fade out music & ui.
                //then return to menu
            }
        }
    }
}
