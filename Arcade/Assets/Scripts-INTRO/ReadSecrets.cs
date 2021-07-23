using System;
using System.Collections;
using UnityEngine;

public class ReadSecrets : MonoBehaviour
{
   public static ReadSecrets Instance;
   [HideInInspector] public TextAsset database;
   private void Awake()
   {
      Instance = this;
      DontDestroyOnLoad(this);
      database = Resources.Load<TextAsset>("database");
   }

   private void Start()
   {
      Debug.Log(database.text);
      //first create Xml, then parse it. 
   }
}
