using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour

{
    public GameObject UIFade;
    private RectTransform UIFadeComp;

    private void Start()
    {
        UIFadeComp = UIFade.GetComponent<RectTransform>();
        StartCoroutine(UIFadeIn());
        UIFade.SetActive(true);
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
        trans.offsetMax = trans.offsetMax +
                          new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));

    }

    public void ReturnToOptionsMenu()
    {
        UIFade.SetActive(true);
        StartCoroutine(Fade());
        StartCoroutine(FadeOutUI());
        
    }

    IEnumerator Fade()
    {
        AudioManager.Instance.Click();
        while (AudioManager.Instance.audio.volume > 0f)
        {
            //Debug.Log("reducing volume"+am.volume);
            AudioManager.Instance.audio.volume -= 0.01f;
            yield return null;
        }

        AudioManager.Instance.audio.volume = 0f;

        
    }

    IEnumerator FadeOutUI()
    {
        while (SetSizeDown(UIFadeComp, -1.8f))

        {
            yield return null;
        }
        SceneManager.LoadScene(1);
    }

    bool SetSizeDown(RectTransform trans, float multiplier)
    {
        Vector2 oldSize = trans.rect.size;
        Vector2 finalSize = oldSize * multiplier * Time.deltaTime;
        trans.offsetMin = trans.offsetMin - new Vector2(finalSize.x * trans.pivot.x, finalSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax +
                          new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));
        Debug.Log(finalSize.x + " | " + finalSize.y);
        if (finalSize.x > -3.3f || finalSize.y > -3.3f)
        {
            //prevent from shrinking too much
            Debug.Log("true, stop-");
            return false;
        }
        else
        {
            return true;
        }
    }
}