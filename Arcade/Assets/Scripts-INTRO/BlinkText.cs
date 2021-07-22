using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public GameObject text;

    private int c;

    // Start is called before the first frame update
    private void Start()
    {
        text.gameObject.SetActive(true);
        InvokeRepeating("Blink", 1f, 0.5f);
    }

    private void Blink()
    {
        if (text.gameObject.activeSelf && c >= 4)
        {
            text.gameObject.SetActive(false);
            c = 0;
        }
        else
        {
            c++;
            text.gameObject.SetActive(true);
        }
    }
}