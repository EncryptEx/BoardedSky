using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUIManager : MonoBehaviour
{
    public GameObject UIFade;
    private RectTransform UIFadeComp;
    private void Start()
    {
        var tutorialReferrer = GameObject.Find("TutorialReferrer");
        if (!tutorialReferrer)
        {
            UIFadeComp = UIFade.GetComponent<RectTransform>();
            StartCoroutine(UIFadeIn());
            UIFade.SetActive(true);
        }
        else
        {
            UIFade.SetActive(false);
            Destroy(tutorialReferrer);
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
