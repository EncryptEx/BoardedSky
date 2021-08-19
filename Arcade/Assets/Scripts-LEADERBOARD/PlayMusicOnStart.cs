using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    private void Start()
    {
        var am = AudioManager.Instance;
        StartCoroutine(am.Fade());
    }
}