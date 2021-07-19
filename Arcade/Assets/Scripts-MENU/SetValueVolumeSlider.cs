using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetValueVolumeSlider : MonoBehaviour
{
    //private AudioManager am;
   void Start()
    {
        //am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        this.GetComponent<Slider>().value = AudioManager.Instance.audio.volume;
    }
}
