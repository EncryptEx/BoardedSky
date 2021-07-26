using System.Xml;
using UnityEngine;

public class ReadSecrets : MonoBehaviour
{
    public static ReadSecrets Instance;
    [HideInInspector] public TextAsset database;
    [HideInInspector] public string getURL;
    [HideInInspector] public string insertURL;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        database = Resources.Load<TextAsset>("database");
        Debug.Log(database.text);
    }

    private void Start()
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(database.text);


        var secrets = xmlDoc.GetElementsByTagName("secrets");
        var get = secrets[0].InnerText;
        var insert = secrets[1].InnerText;

        getURL = get;
        insertURL = insert;
    }
}