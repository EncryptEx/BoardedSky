using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMusicPlay : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioManager am;
    void Start()
    {
        am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        am.PlayAndFadeInGameOverMusic();
    }
}
