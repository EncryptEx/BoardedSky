using UnityEngine;

public class GameMusicTurnOn : MonoBehaviour
{
    private AudioManager am;

    // Start is called before the first frame update
    private void Start()
    {
        am = AudioManager.Instance;
        am.PlayInGameMusic();
    }
}