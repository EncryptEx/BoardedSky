using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager am;

    private void Start()
    {
        am = AudioManager.Instance;
    }

    public void StartGame()
    {
        StartCoroutine(FadeOut());
    }

    public void LoadScore()
    {
        StartCoroutine(LoadScoreBoard());
    }

    public void QuitGame()
    {
        Application.Quit();
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
}