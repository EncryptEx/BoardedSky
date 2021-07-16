using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioManager am;
    public void StartGame()
    {
        am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        StartCoroutine(FadeOut());
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
}
