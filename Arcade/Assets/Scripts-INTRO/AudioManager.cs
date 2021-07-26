using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip[] audios;

    public float volume = 1f;

    // Start is called before the first frame update
    public AudioSource audio;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        volume = 999f;
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = true;
        audio.clip = audios[0];
        audio.loop = true;
        audio.Play();
    }


    // Update is called once per frame
    public void Click()
    {
        var randomAudioClick = Random.Range(1, 2);
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

    public IEnumerator FadeOut()
    {
        Debug.Log("STARTING FADEOUT");
        while (audio.volume > 0f) //for future whould be user's predef. 
        {
            Debug.Log(audio.volume);
            //Debug.Log("augmenting volume"+am.volume);
            audio.volume -= 0.01f;
            yield return null;
        }

        audio.volume = 0f;
    }


    public void PlayAndFadeInGameOverMusic()
    {
        audio.Stop();
        StartCoroutine(Fade());
        audio.PlayOneShot(audios[4]);
    }

    public void PlayOneMoreLife()
    {
        audio.PlayOneShot(audios[6]);
    }

    public void PlayLessLife()
    {
        audio.PlayOneShot(audios[5]);
    }

    public void PlayNitro()
    {
        audio.PlayOneShot(audios[7]);
    }
}