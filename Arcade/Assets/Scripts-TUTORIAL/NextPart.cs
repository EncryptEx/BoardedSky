using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPart : MonoBehaviour
{
    private bool _isPartOne = true;
    public bool isAbleToSkip;
    public TextManager tm;

    //ui
    public GameObject UIFade;
    private RectTransform UIFadeComp;
    

    
    void Start()
    {
        isAbleToSkip = false;
        UIFadeComp = UIFade.GetComponent<RectTransform>();
        StartCoroutine(UIFadeIn());
        UIFade.SetActive(true);
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
                //camera move to fake game
                tm.SetDone();
            }
        }
    }
   IEnumerator UIFadeIn()
    {
        for (int i = 0; i < 100; i++)
        {
            SetSizeUp(UIFadeComp, 2f);
            yield return null;
        }

        UIFade.SetActive(false);
    }

    void SetSizeUp(RectTransform trans, float multiplier)
    {
        Vector2 oldSize = trans.rect.size;
        Vector2 finalSize = oldSize * multiplier * Time.deltaTime;
        trans.offsetMin = trans.offsetMin - new Vector2(finalSize.x * trans.pivot.x, finalSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));

    }
}
