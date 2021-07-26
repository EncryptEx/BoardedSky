using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SubmitScoreData : MonoBehaviour
{
    public GameObject preStatusText;
    public TextMeshProUGUI statusText;
    private readonly string _insertURL = "YOUR URL GOES HERE";

    public void UploadData()
    {
        var userName = GameObject.Find("InputFieldname").GetComponent<InputField>().text;
        var p = Points.Instance;
        var score = p.countt;
        var username = userName;
        var currentTime = p.currentTime;
        var minutes = currentTime / 60f;
        var seconds = currentTime % 60;
        var donewith = minutes.ToString("00") + ":" + seconds.ToString("00");
        var doneat = DateTime.Now.ToString("d");

        //ready to call function.
        statusText = preStatusText.GetComponent<TextMeshProUGUI>();
        StartCoroutine(PostScores(username, score, doneat, donewith));
        preStatusText.SetActive(true);
    }

    public IEnumerator PostScores(string username, int score, string doneat, string donewith)
    {
        Debug.Log("POST SCORES WORKING");
        var uri = _insertURL + "name=" + UnityWebRequest.EscapeURL(username) + "&score=" + score + "&doneat=" +
                  UnityWebRequest.EscapeURL(doneat) + "&donewith=" +
                  UnityWebRequest.EscapeURL(donewith);

        using (var webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    statusText.text = webRequest.error;
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    statusText.text = webRequest.error;
                    break;
                case UnityWebRequest.Result.Success:
                    statusText.text = "Record succesfully saved.";
                    break;
            }
        }
    }
}