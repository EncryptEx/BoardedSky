using UnityEngine;
using UnityEngine.UI;

public class SetValueVolumeSlider : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Slider>().value = AudioManager.Instance.audio.volume;
    }
}