using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTextScript : MonoBehaviour
{
    public GameOverScript g;

    public GameOverTextScript Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if (g.gameover && SceneManager.GetActiveScene().buildIndex == 3) //check if is game........
            if (GetComponent<RectTransform>().position.z <= -1.9)
            {
                Destroy(GetComponent<Rigidbody>());
                SceneManager.LoadScene(4); //game to end
            }
    }
}