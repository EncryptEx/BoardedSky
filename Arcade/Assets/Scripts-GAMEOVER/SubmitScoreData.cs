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
        var donewith = p.currentTime;
        var doneat = Time.time;

        //ready to call function.
        statusText = preStatusText.GetComponent<TextMeshProUGUI>();
        StartCoroutine(PostScores(username, score, doneat, donewith));
        preStatusText.SetActive(true);
    }

    public IEnumerator PostScores(string username, int score, float doneat, float donewith)
    {
        Debug.Log("POST SCORES WORKING");
        var uri = _insertURL + "name=" + UnityWebRequest.EscapeURL(username) + "&score=" + score + "&doneat=" +
                  UnityWebRequest.EscapeURL(doneat.ToString()) + "&donewith=" +
                  UnityWebRequest.EscapeURL(donewith.ToString());

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