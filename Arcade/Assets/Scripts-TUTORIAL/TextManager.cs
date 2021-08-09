using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI MainText;
    
    //gameobjects and texts variables: 
    //case 0 and 1
    public GameObject playerTextGameObject;
    [HideInInspector] public TextMeshProUGUI playerTextUGUI;
    public GameObject fakePlayer;
    public GameObject tilterTextGameObject;
    [HideInInspector] public TextMeshProUGUI tilterTextUGUI;
    
    //case 2
    public GameObject hearts;
    public GameObject heartTextGameObject;
    [HideInInspector] public TextMeshProUGUI heartText;
    
    //case 3
    public GameObject ghearts;
    public GameObject goldenTextGameObject;
    [HideInInspector] public TextMeshProUGUI goldenUGUI;
    
    // internal variables for typewriter work
    private string _finalText = "";
    private bool isDone;

    //coroutinesaver
    private Coroutine coroutineSaver;
    
    // counter of how many times typewritter has finished
    private int howManyDones = 0;
    
    
    
    private void Start()
    {
        //GameObject Findings and declarations
        playerTextUGUI = playerTextGameObject.GetComponent<TextMeshProUGUI>();
        tilterTextUGUI = tilterTextGameObject.GetComponent<TextMeshProUGUI>();
        heartText = heartTextGameObject.GetComponent<TextMeshProUGUI>();
        goldenUGUI = goldenTextGameObject.GetComponent<TextMeshProUGUI>();
        
        
        //IMPORTANT STUFF
        var textToWrite = "Welcome player!\n" +
                          "I'm glad to teach you how the game works.\n" +
                          "Let's start with the basics:\n";
        isDone = false;
        coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, MainText));
    }


    private void Update()
    {
        if (isDone)
        { 
            var textToWrite = "";
            switch (howManyDones)
            {
                   
                case 0: // player fake moment
                    NewCaseProtocol();
                    fakePlayer.SetActive(true);
                    playerTextGameObject.SetActive(true);
                    textToWrite = "Use A and D keys to move";
                    coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, playerTextUGUI));
                    break;
                case 1: // tilt moment 
                    NewCaseProtocol();
                    tilterTextGameObject.SetActive(true);
                    textToWrite = "and W and S keys to tilt";
                    coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, tilterTextUGUI));
                    break;
                
                case 2: //lives moment
                    NewCaseProtocol();
                    
                    break;
                case 3: // golden moment
                    break;
            }
            
        }
    }


    void NewCaseProtocol()
    {
        howManyDones++;
        StopCoroutine(coroutineSaver);
        isDone = false;
    }

    IEnumerator StartTypeWritter(string passedValue, TextMeshProUGUI textTarget)
    {
        for (int i = 0; i < passedValue.Length; i++)
        {
            TypeWritter(passedValue, i, textTarget);
            yield return new WaitForSeconds(0.05f);
        }

        _finalText = "";
        isDone = true;
    }
    
    private void  TypeWritter(string text, int letterValue, TextMeshProUGUI textTarget)
    {
        char[] characters = text.ToCharArray();
        _finalText += characters[letterValue];
        
        // rewrite on text.
        textTarget.text = _finalText;
    }
}
