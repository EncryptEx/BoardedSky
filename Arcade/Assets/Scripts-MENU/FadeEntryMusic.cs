using UnityEngine;

public class FadeEntryMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioManager am;

    private void Start()
    {
        am = AudioManager.Instance;
        AudioManager.Instance.Click();
        StartCoroutine(am.Fade());
        Debug.Log("Starting coroutine entry music at intro.");
    }
}