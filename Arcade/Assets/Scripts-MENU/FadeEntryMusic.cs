using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEntryMusic : MonoBehaviour
{
    // Start is called before the first frame update
    // public AudioManager am;
    void Start()
    {
        //am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        AudioManager.Instance.Click();
        StartCoroutine(AudioManager.Instance.Fade());
        Debug.Log("Starting coroutine entry music at intro.");
    }
    
    
}
