using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKeyDown) StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        AudioManager.Instance.Click();
        while (AudioManager.Instance.audio.volume > 0f)
        {
            //Debug.Log("reducing volume"+am.volume);
            AudioManager.Instance.audio.volume -= 0.01f;
            yield return null;
        }

        AudioManager.Instance.audio.volume = 0f;

        SceneManager.LoadScene(1);
    }
}