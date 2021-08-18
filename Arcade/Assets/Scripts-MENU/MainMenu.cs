using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject UIFade;
    private AudioManager am;
    private bool isAvailableToPress;
    private RectTransform UIFadeComp;

    private void Start()
    {
        isAvailableToPress = true;
        am = AudioManager.Instance;
        UIFadeComp = UIFade.GetComponent<RectTransform>();
    }

    public void StartGame()
    {
        if (isAvailableToPress)
        {
            StartCoroutine(FadeOut());
            UIFade.SetActive(true);
            StartCoroutine(FadeOutUI());
            isAvailableToPress = false;
        }
    }

    public void LoadScore()
    {
        if (isAvailableToPress)
        {
            StartCoroutine(LoadScoreBoard());
            UIFade.SetActive(true);
            StartCoroutine(FadeOutUI());
            isAvailableToPress = false;
        }
    }

    public void LoadTutorial()
    {
        if (isAvailableToPress)
        {
            StartCoroutine(TutorialLoad());
            UIFade.SetActive(true);
            StartCoroutine(FadeOutUI());
            isAvailableToPress = false;
        }
    }
    
    public void QuitGame()
    {
        if (isAvailableToPress)
        {
            isAvailableToPress = false;
            Application.Quit();
        }
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("STARTING FADEOUT");
        while (am.asrc.volume > 0f) //for future whould be user's predef. 
        {
            //Debug.Log(am.asrc.volume);
            //Debug.Log("augmenting volume"+am.volume);
            am.asrc.volume -= 0.01f;
            yield return null;
        }

        am.asrc.volume = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator LoadScoreBoard()
    {
        Debug.Log("STARTING FADEOUT SCOREBOARD");
        while (am.asrc.volume > 0f) //for future whould be user's predef. 
        {
            //Debug.Log(am.asrc.volume);
            //Debug.Log("augmenting volume"+am.volume);
            am.asrc.volume -= 0.01f;
            yield return null;
        }

        am.asrc.volume = 0f;
        SceneManager.LoadScene(4);
    }

    private IEnumerator FadeOutUI()
    {
        while (SetSizeDown(UIFadeComp, -1.8f)) yield return null;
    }

    private bool SetSizeDown(RectTransform trans, float multiplier)
    {
        var oldSize = trans.rect.size;
        var finalSize = oldSize * multiplier * Time.deltaTime;
        trans.offsetMin = trans.offsetMin - new Vector2(finalSize.x * trans.pivot.x, finalSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax +
                          new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));
        //Debug.Log(finalSize.x+" | "+finalSize.y);
        if (finalSize.x > -3.3f || finalSize.y > -3.3f)
        {
            //prevent from shrinking too much
            Debug.Log("true, stop-");
            return false;
        }

        return true;
    }
    
    private IEnumerator TutorialLoad()
    {
        Debug.Log("STARTING FADEOUT TUTORIAL");
        while (am.asrc.volume > 0f) //for future whould be user's predef. 
        {
            //Debug.Log(am.asrc.volume);
            //Debug.Log("augmenting volume"+am.volume);
            am.asrc.volume -= 0.01f;
            yield return null;
        }

        am.asrc.volume = 0f;
        SceneManager.LoadScene(5);
    }
}