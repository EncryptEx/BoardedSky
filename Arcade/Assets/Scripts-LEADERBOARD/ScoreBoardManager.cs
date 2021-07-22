using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreBoardManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;

    private readonly string _getURL = "YOUR URL GOES HERE";
    // Start is called before the first frame update

    private readonly string _insertURL = "YOUR URL GOES HERE";

    private void Start()
    {
        StartCoroutine(GetRequest(_getURL));
        statusText.text = "Loading"; //prevent from seeing test data.
    }

    private IEnumerator GetRequest(string uri)
    {
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
                    statusText.text = webRequest.downloadHandler.text;
                    break;
            }
        }
    }


    public IEnumerator PostScores(string name, int score, string doneat, string donewith)
    {
        var addRecordURL = _insertURL + "name=" + UnityWebRequest.EscapeURL(name) + "&score=" + score + "&doneat=" +
                           UnityWebRequest.EscapeURL(doneat) + "&donewith=" + UnityWebRequest.EscapeURL(donewith);

        var request = new UnityWebRequest(addRecordURL);
        yield return request; // Wait

        if (request.error != null) Debug.Log("There was an error posting the high score: " + request.error);
    }
}