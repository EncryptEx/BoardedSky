using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ActionsLogger : MonoBehaviour
{
    public TextMeshProUGUI logText;
    
    public void WriteOnLogText(string textToWrite)
    {
        logText.text = textToWrite;
        Invoke("CleanLogText",2);
    }

    void CleanLogText()
    {
        logText.text = "";
    }
}
