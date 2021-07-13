using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audios;
    
    // Start is called before the first frame update
    private AudioSource audio;
    
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        audio.playOnAwake = true;
        audio.clip = audios[0];
        audio.loop = true;
        audio.Play();
    }

    // Update is called once per frame
    public void Click()
    {
        int randomAudioClick = UnityEngine.Random.Range(1, 2);
        audio.PlayOneShot(audios[randomAudioClick]); //click
    }
}
