using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager am;
    
    public GameObject UIFade;
    private RectTransform UIFadeComp;
    private bool isAvailableToPress;
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
        while (am.audio.volume > 0f) //for future whould be user's predef. 
        {
            Debug.Log(am.audio.volume);
            //Debug.Log("augmenting volume"+am.volume);
            am.audio.volume -= 0.01f;
            yield return null;
        }

        am.audio.volume = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator LoadScoreBoard()
    {
        Debug.Log("STARTING FADEOUT SCOREBOARD");
        while (am.audio.volume > 0f) //for future whould be user's predef. 
        {
            Debug.Log(am.audio.volume);
            //Debug.Log("augmenting volume"+am.volume);
            am.audio.volume -= 0.01f;
            yield return null;
        }

        am.audio.volume = 0f;
        SceneManager.LoadScene(4);
    }
    IEnumerator FadeOutUI()
    {
        while (SetSizeDown(UIFadeComp,-1.8f))
            
        {
            yield return null;  
        }
    }
    
    bool SetSizeDown(RectTransform trans, float multiplier) {
        Vector2 oldSize = trans.rect.size;
        Vector2 finalSize = oldSize * multiplier * Time.deltaTime;
        trans.offsetMin = trans.offsetMin - new Vector2(finalSize.x * trans.pivot.x, finalSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + new Vector2(finalSize.x * (1f - trans.pivot.x), finalSize.y * (1f - trans.pivot.y));
        Debug.Log(finalSize.x+" | "+finalSize.y);
        if (finalSize.x > -3.3f || finalSize.y > -3.3f)
        {
            //prevent from shrinking too much
            Debug.Log("true, stop-");
            return false;
        } else  {
            return true;
        }
    }
}