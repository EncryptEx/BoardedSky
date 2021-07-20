using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public bool gameover = false;
    public GameObject GameOverText;
    public GameObject walls;
    public GameObject player;
    public GameObject uiToDelete;
    public float force = 1f;

    private AudioManager am;
    
    [Tooltip("Game Over Light")] public GameObject gameOverLight;
    
    public GameOverScript Instance;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }


    private void Start()
    {
        am = GameObject.Find("SoundSystem").GetComponent<AudioManager>();
        gameover = false; //always!
    }

    public void GameOver()
    {
        gameover = true;
        
        gameOverLight.SetActive(true);
        //operacion brick down
        var bricks = GameObject.FindGameObjectsWithTag("brick");
        foreach (var brick in bricks)
        {
            var rb = brick.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(new Vector3(Random.Range(-1f,1f)*force,0,Random.Range(-1f,1f)*force));
        }

        StartCoroutine(am.FadeOut());
        walls.AddComponent<Rigidbody>();
        player.AddComponent<Rigidbody>();
        GameOverText.AddComponent<Rigidbody>();
        Destroy(uiToDelete);
            
        var alt = GameOverText.gameObject.GetComponent<RectTransform>().position.y;
        
        
        //just for debug
        Debug.Log("Game OVER");
        
    }
    
    
    
    
    
}
