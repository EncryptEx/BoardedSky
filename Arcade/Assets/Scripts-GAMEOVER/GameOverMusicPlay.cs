using UnityEngine;

public class GameOverMusicPlay : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioManager am;

    private void Start()
    {
        am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        am.PlayAndFadeInGameOverMusic();
    }
}