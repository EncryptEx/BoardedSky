using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audios;

    public float volume = 1f;
    // Start is called before the first frame update
    public AudioSource audio;
    
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        volume = 999f;
        audio = this.GetComponent<AudioSource>();
        audio.playOnAwake = true;
        audio.clip = audios[0];
        audio.loop = true;
        audio.Play();
    
    }

    private void Update()
    {
        if (volume != 999f)
        {
            Debug.Log("volume now is set. to"+volume);
            audio.volume = volume;
        }
    }

    // Update is called once per frame
    public void Click()
    {
        int randomAudioClick = UnityEngine.Random.Range(1, 2);
        audio.PlayOneShot(audios[randomAudioClick]); //click
    }

    public void PlayInGameMusic()
    {
        //but first a fade ENTRY
        audio.Stop();
        audio.clip = audios[3];
        audio.loop = true;
        audio.Play();
        StartCoroutine(Fade());
    
    }
    
    public IEnumerator Fade()
    {
        Debug.Log("STARTING FADEIN");
        while (audio.volume < 1f) //for future whould be user's predef. 
        {
            Debug.Log(audio.volume);
            //Debug.Log("augmenting volume"+am.volume);
            audio.volume += 0.01f;
            yield return null;
        }

        audio.volume = 1f;

    }
    
    
}
