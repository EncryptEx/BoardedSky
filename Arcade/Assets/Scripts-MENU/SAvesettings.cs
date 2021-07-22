using UnityEngine;

public class SAvesettings : MonoBehaviour
{
    public AudioManager am;
    public DifficultyBrickSaver bd;

    private void Start()
    {
        am = GameObject.FindGameObjectWithTag("soundsys").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    public void UpdateVolume(float volume)
    {
        am.audio.volume = volume;
    }

    public void UpdateDifficulty(float diff)
    {
        bd.diff = diff;
    }
}