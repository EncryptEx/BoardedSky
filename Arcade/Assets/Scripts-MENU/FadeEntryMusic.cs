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
        UIFade.SetActive(true);
        am = AudioManager.Instance;
        AudioManager.Instance.Click();
        StartCoroutine(am.Fade());
        StartCoroutine(UIFadeIn());
        Debug.Log("Starting coroutine entry music at intro.");
    }

    private IEnumerator UIFadeIn()
    {
        for (var i = 0; i < 100; i++)
        {
            SetSizeUp(UIFadeComp, 2f);
            yield return null;
        }

        UIFade.SetActive(false);
    }

    private void SetSizeUp(RectTransform trans, float multiplier)
    {
        var oldSize = trans.rect.size;
        var finalSize = oldSize * multiplier * Time.deltaTime;
        trans.offsetMin = trans.offsetMin - new Vector2(finalSize.x * trans.pivot.x, finalSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax +
                          new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));
    }
}