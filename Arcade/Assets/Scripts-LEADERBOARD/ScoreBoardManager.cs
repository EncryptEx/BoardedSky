using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
public class ScoreBoardManager : MonoBehaviour
{
    // Start is called before the first frame update

    private string _insertURL = "YOUR URL GOES HERE";
    private string _getURL = "YOUR URL GOES HERE";
    public TextMeshProUGUI statusText;
   
    void Start()
    {
        StartCoroutine(GetRequest(_getURL));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

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
        string addRecordURL = _insertURL + "name=" + UnityWebRequest.EscapeURL(name) + "&score=" + score + "&doneat="+UnityWebRequest.EscapeURL(doneat)+"&donewith="+UnityWebRequest.EscapeURL(donewith);
        
        UnityWebRequest request = new UnityWebRequest(addRecordURL);
        yield return request; // Wait

        if (request.error != null)
        {
            Debug.Log("There was an error posting the high score: " + request.error);
        }
    }
}
