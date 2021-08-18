using UnityEngine;

public class BlinkTextForTutorial : MonoBehaviour
{
    private int c;
    public NextPart np;

    // Start is called before the first frame update
    public void StartBlinking()
    {
        this.gameObject.SetActive(true);
        InvokeRepeating("Blink", 1f, 0.5f);
    }

    private void Blink()
    {
        if (np.isAbleToSkip)
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
        else
        {
            gameObject.SetActive(false);
        }
        
    }
}