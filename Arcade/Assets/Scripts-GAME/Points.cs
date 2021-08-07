using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points Instance;
    public int countt;
    public TextMeshProUGUI countText;
    public GameOverScript go; //to stop chrono and points after being dead.

    public TextMeshProUGUI timeText;

    public float currentTime;

    private Points _points;

    private float startedTime;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        timeText.text = "00:00";
        startedTime = Time.time;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!go.gameover)
        {
            currentTime = Time.time - startedTime;
            var minutes = currentTime / 60f;
            var seconds = currentTime % 60;
            timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void Updatecounter(int count)
    {
        countt = countt + count;
        if (countt > 999) countText.fontSize = 60f;
        if (countt > 9999) countText.fontSize = 48f;
        if (countt > 99999) countText.fontSize = 41.5f;
        countText.text = countt.ToString();
    }
}