using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{
    public GameObject UIFade;
    private bool isAvailableToPress;
    private RectTransform UIFadeComp;

    // Start is called before the first frame update
    private void Start()
    {
        UIFadeComp = UIFade.GetComponent<RectTransform>();
        UIFade.SetActive(false);
        isAvailableToPress = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isAvailableToPress)
            if (Input.anyKeyDown)
            {
                isAvailableToPress = false;
                StartCoroutine(Fade());
                UIFade.SetActive(true);
                StartCoroutine(FadeOutUI());
            }
    }

    public IEnumerator Fade()
    {
        AudioManager.Instance.Click();
        while (AudioManager.Instance.asrc.volume > 0f)
        {
            //Debug.Log("reducing volume"+AudioManager.Instance.asrc.volume);
            AudioManager.Instance.asrc.volume -= 0.15f * Time.deltaTime;
            yield return null;
        }

        AudioManager.Instance.asrc.volume = 0f;

        SceneManager.LoadScene(2);//intro to menu
    }

    private IEnumerator FadeOutUI()
    {
        while (SetSizeDown(UIFadeComp, -1.8f)) yield return null;
    }

    private bool SetSizeDown(RectTransform trans, float multiplier)
    {
        var oldSize = trans.rect.size;
        var finalSize = oldSize * multiplier * Time.deltaTime;
        
        //Debug.Log(finalSize.x+" | "+finalSize.y);
        if (finalSize.x > -5f || finalSize.y > -5f)
        {
            //prevent from shrinking too much
            Debug.Log("true, stop:- " + finalSize.x + " | " + finalSize.y);
            return false;
        }
        trans.offsetMin = trans.offsetMin - new Vector2(finalSize.x * trans.pivot.x, finalSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax +
                          new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));
        return true;
    }
}