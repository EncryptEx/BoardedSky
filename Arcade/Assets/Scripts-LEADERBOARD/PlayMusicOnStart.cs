using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
   
    void Start()
    {
        var am = AudioManager.Instance;
        StartCoroutine(am.Fade());
    }

}
