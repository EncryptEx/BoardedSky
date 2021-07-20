using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicTurnOn : MonoBehaviour
{
    private AudioManager am;
    // Start is called before the first frame update
    void Start()
    {
        am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        am.PlayInGameMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
