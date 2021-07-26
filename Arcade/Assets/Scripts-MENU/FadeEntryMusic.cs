using System.Collections;
using UnityEngine;

public class FadeEntryMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioManager am;
    public GameObject UIFade;
    private RectTransform UIFadeComp;
    private void Start()
    {
        UIFadeComp = UIFade.GetComponent<RectTransform>();
        am = AudioManager.Instance;
        AudioManager.Instance.Click();
        StartCoroutine(am.Fade());
        StartCoroutine(UIFadeIn());
        Debug.Log("Starting coroutine entry music at intro.");
    }

    IEnumerator UIFadeIn()
    {
        for (int i = 0; i < 100; i++)
        {
            SetSizeUp(UIFadeComp,2f);
            yield return null;
        }

        UIFade.SetActive(false);
    }
     void SetSizeUp(RectTransform trans, float multiplier) {
        Vector2 oldSize = trans.rect.size;
        Vector2 finalSize = oldSize * multiplier * Time.deltaTime;
        trans.offsetMin = trans.offsetMin - new Vector2(finalSize.x * trans.pivot.x, finalSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));
        
    }
}