using UnityEngine;

public class SAvesettings : MonoBehaviour
{
    public AudioManager am;
    public DifficultyBrickSaver bd;

    private void Start()
    {
        am = AudioManager.Instance;
    }

    // Start is called before the first frame update
    public void UpdateVolume(float volume)
    {
        am.asrc.volume = volume;
        if (!am.hasEditedVolume) am.hasEditedVolume = true;
        am.predefVolume = volume;
    }

    public void UpdateDifficulty(float diff)
    {
        bd.diff = diff;
    }
}