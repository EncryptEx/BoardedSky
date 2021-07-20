using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetValueVolumeSlider : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Slider>().value = AudioManager.Instance.audio.volume;
    }
}
