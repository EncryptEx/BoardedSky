using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEntryMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioManager am;
    void Start()
    {
        am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        StartCoroutine(Fade());
    }


    public IEnumerator Fade()
    {
        AudioManager.Instance.Click();
        while (am.volume < 1f) //for future whould be user's predef. 
        {
            //Debug.Log("augmenting volume"+am.volume);
            am.volume += 0.01f;
            yield return null;
        }

        am.volume = 100f;

    }
    
}
