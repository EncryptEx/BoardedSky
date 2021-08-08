using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip[] audios;
    public bool hasEditedVolume;
    public float predefVolume;

    // Start is called before the first frame update
    public AudioSource asrc;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        asrc = GetComponent<AudioSource>();
        asrc.playOnAwake = true;
        asrc.clip = audios[0];
        asrc.loop = true;
        asrc.volume = 0.8f;
        asrc.Play();
    }


    // Update is called once per frame
    public void Click()
    {
        var randomAudioClick = Random.Range(1, 2);
        asrc.PlayOneShot(audios[randomAudioClick]); //click
    }

    public void PlayInGameMusic()
    {
        //but first a fade ENTRY
        asrc.Stop();
        asrc.clip = audios[3];
        asrc.loop = true;
        asrc.Play();
        StartCoroutine(Fade());
    }

    public IEnumerator Fade()
    {
        Debug.Log("STARTING FADEIN");
        var wantedVolume = hasEditedVolume ? predefVolume : 1f;
        while (asrc.volume < wantedVolume) //for future whould be user's predef. 
        {
            //Debug.Log("augmenting volume"+asrc.volume);
            asrc.volume += 0.01f;
            yield return null;
        }

        asrc.volume = 1f;
    }

    public IEnumerator FadeOut()
    {
        Debug.Log("STARTING FADEOUT");
        while (asrc.volume > 0f) //for future whould be user's predef. 
        {
            //Debug.Log(asrc.volume);
            //Debug.Log("augmenting volume"+am.volume);
            asrc.volume -= 0.01f;
            yield return null;
        }

        asrc.volume = 0f;
    }


    public void PlayAndFadeInGameOverMusic()
    {
        asrc.Stop();
        StartCoroutine(Fade());
        asrc.PlayOneShot(audios[4]);
    }

    public void PlayOneMoreLife()
    {
        asrc.PlayOneShot(audios[6]);
    }

    public void PlayLessLife()
    {
        asrc.PlayOneShot(audios[5]);
    }

    public void PlayNitro()
    {
        asrc.PlayOneShot(audios[7]);
    }
}