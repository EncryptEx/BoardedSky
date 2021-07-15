using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public int countt;
    public TextMeshProUGUI countText;
    public GameOverScript go; //to stop chrono and points after being dead.
    public TextMeshProUGUI timeText;
    public static Points Instance;
    // Start is called before the first frame update
    private float startedTime;
   void Start()
    {
        timeText.text = "00:00";
        startedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!go.gameover)
        {
            var currentTime = Time.time - startedTime;
            var minutes = currentTime / 60f;
            var seconds = currentTime % 60;
            timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void Updatecounter(int count)
    {
        countt = countt + count;
        if(countt>1000)
        {
            countText.fontSize = 60f;
        }
        countText.text = countt.ToString();
    }
    
   

    
    
}
