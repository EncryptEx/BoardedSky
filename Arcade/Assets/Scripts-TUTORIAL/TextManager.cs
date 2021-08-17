using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject mainTextGameObject;
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
    [HideInInspector] public TextMeshProUGUI heartTextUGUI;
    
    //case 3
    public GameObject ghearts;
    public GameObject goldenTextGameObject;
    [HideInInspector] public TextMeshProUGUI goldenUGUI;
    
    //case 4
    public BlinkTextForTutorial pressAnyKeyToContinue;
    public NextPart np;
    
    
    // PART 2
    //start part 2
    public GameObject backgroundWall;
    
    //case 0
    public GameObject brickText1GameObject;
    [HideInInspector] public TextMeshProUGUI brickText1;
    public GameObject brickModel;
    
    //case 1
    public GameObject brickText2GameObject;
    [HideInInspector] public TextMeshProUGUI brickText2;
    public GameObject hardBrickModel;
    
    // internal variables for typewriter work
    private string _finalText = "";
    private bool _isDone;

    //coroutinesaver
    private Coroutine _coroutineSaver;
    
    // counter of how many times typewritter has finished
    private int _howManyDones = 0;
    
    //part counter;
    private int _partType = 1;
    
    
    private void Start()
    {
        _partType = 1;
        
        //GameObject Findings and declarations
        playerTextUGUI = playerTextGameObject.GetComponent<TextMeshProUGUI>();
        tilterTextUGUI = tilterTextGameObject.GetComponent<TextMeshProUGUI>();
        heartTextUGUI = heartTextGameObject.GetComponent<TextMeshProUGUI>();
        goldenUGUI = goldenTextGameObject.GetComponent<TextMeshProUGUI>();
        pressAnyKeyToContinue = pressAnyKeyToContinue.GetComponent<BlinkTextForTutorial>();
        brickText1 = brickText1GameObject.GetComponent<TextMeshProUGUI>();
        brickText2 = brickText2GameObject.GetComponent<TextMeshProUGUI>();
        
        //IMPORTANT STUFF
        //case "-1"  = pre all.
        backgroundWall.SetActive(true);

        mainTextGameObject.SetActive(true);
        var textToWrite = "Welcome player!\n" +
                          "I'm glad to teach you how the game works.\n" +
                          "Let's start with the basics:\n";
        _isDone = false;
        _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, MainText));
    }


    private void Update()
    {
        if (_isDone && _partType == 1)
        { 
            string textToWrite;
            switch (_howManyDones)
            {
                   
                case 0: // player fake moment
                    NewCaseProtocol();
                    fakePlayer.SetActive(true);
                    playerTextGameObject.SetActive(true);
                    textToWrite = "Use A and D keys to move";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, playerTextUGUI));
                    break;
                case 1: // tilt moment 
                    NewCaseProtocol();
                    tilterTextGameObject.SetActive(true);
                    textToWrite = "and W and S keys to tilt";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, tilterTextUGUI));
                    break;
                
                case 2: //lives moment
                    NewCaseProtocol();
                    hearts.SetActive(true);
                    heartTextGameObject.SetActive(true);
                    textToWrite = "You have lives and you die when you reach 0.";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, heartTextUGUI));
                    break;
                case 3: // golden moment
                    NewCaseProtocol();
                    ghearts.SetActive(true);
                    goldenTextGameObject.SetActive(true);
                    textToWrite = "Extra lives are golden:";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, goldenUGUI));
                    break;
                case 4:
                    NewCaseProtocol();
                    pressAnyKeyToContinue.StartBlinking();
                    np.isAbleToSkip = true;
                    break;
            }
            
        }

        if (_isDone && _partType == 2) //part 2
        {
            Debug.Log("detected part 2 - is ready");
            string textToWrite;
            switch (_howManyDones)
            {
                case 0:
                    NewCaseProtocol();
                    
                    brickText1GameObject.SetActive(true);
                    textToWrite = "The objective is to destroy all the bricks";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, brickText1));
                    break;
                case 1:
                    NewCaseProtocol();
                    brickText2GameObject.SetActive(true);
                        textToWrite = "But there are someones that are harder to break depending of their color";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, brickText2));
                    break;
                
                case 2: 
                    NewCaseProtocol();
                    
                    heartTextGameObject.SetActive(true);
                    textToWrite = "You have lives and you die when you reach 0.";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, heartTextUGUI));
                    break;
                    
            }
        }
    }


    void NewCaseProtocol()
    {
        _howManyDones++;
        StopCoroutine(_coroutineSaver);
        _isDone = false;
    }

    IEnumerator StartTypeWritter(string passedValue, TextMeshProUGUI textTarget)
    {
        for (int i = 0; i < passedValue.Length; i++)
        {
            TypeWritter(passedValue, i, textTarget);
            yield return new WaitForSeconds(0.05f);
        }

        _finalText = "";
        _isDone = true;
    }
    
    private void  TypeWritter(string text, int letterValue, TextMeshProUGUI textTarget)
    {
        char[] characters = text.ToCharArray();
        _finalText += characters[letterValue];
        
        // rewrite on text.
        textTarget.text = _finalText;
    }


    public void StartPart2()
    {
        Debug.Log("start part 2 process start");
        _partType=2;
        MainText.text = "";
        playerTextGameObject.SetActive(false);
        fakePlayer.SetActive(false);
        tilterTextGameObject.SetActive(false);
        hearts.SetActive(false);
        ghearts.SetActive(false);
        heartTextGameObject.SetActive(false);
        goldenTextGameObject.SetActive(false);
        pressAnyKeyToContinue.HideMe();
        backgroundWall.SetActive(false);
        Invoke("ExecutePartTwo", 0.3f);
    }

    private void ExecutePartTwo()
    {
        Debug.Log("Start part 2 sub process");
        _howManyDones = 0;
        _isDone = true;
        this.gameObject.SetActive(true);
    }
    
    
}
