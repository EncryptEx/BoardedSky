using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{
    public AudioManager am;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
           StartCoroutine(Fade());
        }
    }

    public IEnumerator Fade()
    {
        AudioManager.Instance.Click();
        while (am.audio.volume > 0f)
        {
            //Debug.Log("reducing volume"+am.volume);
            am.audio.volume -= 0.01f;
            yield return null;
        }

        am.audio.volume = 0f;
        
        SceneManager.LoadScene(1);
    }
}
