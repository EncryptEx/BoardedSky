using UnityEngine;

public class BlinkText : MonoBehaviour
{
   private int c;

    // Start is called before the first frame update
    private void Start()
    {
        this.gameObject.SetActive(true);
        InvokeRepeating("Blink", 1f, 0.5f);
    }

    private void Blink()
    {
        if (this.gameObject.activeSelf && c >= 4)
        {
            this.gameObject.SetActive(false);
            c = 0;
        }
        else
        {
            c++;
            this.gameObject.SetActive(true);
        }
    }
}