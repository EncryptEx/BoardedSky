using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameObject mainTextGameObject;
    [HideInInspector] public TextMeshProUGUI mainText;
    
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
    public GameObject gHearts;
    public GameObject goldenTextGameObject;
    [HideInInspector] public TextMeshProUGUI goldenUGUI;
    
    //case 4
    public BlinkTextForTutorial pressAnyKeyToContinue;
    [HideInInspector] public TextMeshProUGUI pressAnyKeyText;
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
    
    //case 2 - spawn balls
    public GameObject ballPrefab;
    [Tooltip("Force used to impulse ball to brick models for the tutorial, part 2")]
    public float initialForce;
    public void SpawnNewBall()
    {
        Debug.Log("Creating a New Ball.");
        var ballInstance = Instantiate(ballPrefab);
        ballInstance.transform.position = new Vector3(11f,3.55f,45f);
        var rbBallInstance = ballInstance.GetComponent<Rigidbody>();
        rbBallInstance.AddForce(new Vector3(0f, 0f, -2) * initialForce);
    }
    
    //case 3 - nitro:
    public GameObject nitroTextGameObject;
    [HideInInspector] public TextMeshProUGUI nitroText;
    public GameObject nitro;
    
    //case 4 - power up
    public GameObject powerUpTextGameObject;
    [HideInInspector] public TextMeshProUGUI powerText;
    
    //case 5 - red pill
    public GameObject redPill;
    public GameObject redTextGameObject;
    [HideInInspector] public TextMeshProUGUI redText;
    
    //case 6 - green pill
    public GameObject greenPill;
    public GameObject greenTextGameObject;
    [HideInInspector] public TextMeshProUGUI greenText;
    
    //case 7 - blue pill
    public GameObject bluePill;
    public GameObject blueTextGameObject;
    [HideInInspector] public TextMeshProUGUI blueText;


    
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
        nitroText = nitroTextGameObject.GetComponent<TextMeshProUGUI>();
        powerText = powerUpTextGameObject.GetComponent<TextMeshProUGUI>();
        redText = redTextGameObject.GetComponent<TextMeshProUGUI>();
        blueText = blueTextGameObject.GetComponent<TextMeshProUGUI>();
        redText = redTextGameObject.GetComponent<TextMeshProUGUI>();
        pressAnyKeyText = pressAnyKeyToContinue.GetComponent<TextMeshProUGUI>();
        mainText = mainTextGameObject.GetComponent<TextMeshProUGUI>();
        
        //IMPORTANT STUFF
        //case "-1"  = pre all.
        backgroundWall.SetActive(true);
        _isDone = false;
        Invoke("SetDone",3);
    }


    private void Update()
    {
        if (_isDone && _partType == 1)
        { 
            string textToWrite;
            switch (_howManyDones)
            {
                
                case 0:
                    _howManyDones++;
                    _isDone = false;
                    mainTextGameObject.SetActive(true);
                    textToWrite = "Welcome player!\n" +
                                      "This is an interactive tutorial.\n" +
                                      "Let's start with the basics:\n";
                    
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, mainText,true));
                   break;
                case 1: // player fake moment
                    NewCaseProtocol();
                    fakePlayer.SetActive(true);
                    playerTextGameObject.SetActive(true);
                    textToWrite = "Use A and D keys to move";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, playerTextUGUI,true));
                    break;
                case 2: // tilt moment 
                    NewCaseProtocol();
                    tilterTextGameObject.SetActive(true);
                    textToWrite = "and W and S keys to tilt";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, tilterTextUGUI,false));
                    break;
                
                case 3: //lives moment
                    NewCaseProtocol();
                    hearts.SetActive(true);
                    heartTextGameObject.SetActive(true);
                    textToWrite = "You have lives and you die when you reach 0.";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, heartTextUGUI,true));
                    break;
                case 4: // golden moment
                    NewCaseProtocol();
                    gHearts.SetActive(true);
                    goldenTextGameObject.SetActive(true);
                    textToWrite = "Extra lives are golden:";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, goldenUGUI,true));
                    break;
                case 5:
                    NewCaseProtocol();
                    pressAnyKeyText.text = "Click anywhere to continue";
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
                    brickModel.SetActive(true);
                    brickText1GameObject.SetActive(true);
                    textToWrite = "The objective is to destroy all the bricks";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, brickText1,true));
                    break;
                case 1:
                    NewCaseProtocol();
                    hardBrickModel.SetActive(true);
                    brickText2GameObject.SetActive(true);
                        textToWrite = "But there are some of them that are harder to break depending of their color";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, brickText2,true));
                    break;
                
                case 2: 
                    NewCaseProtocol();
                    //ball demo starts.
                    SpawnNewBall();
                    break;
                case 3:
                    NewCaseProtocol();
                    nitro.SetActive(true);
                    nitroTextGameObject.SetActive(true);
                    textToWrite = "Nitro allows you to go faster for some seconds. You can use it with the SPACE BAR";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, nitroText,false));
                    break;
                case 4:
                    NewCaseProtocol();
                    powerUpTextGameObject.SetActive(true);
                    textToWrite = "And finally, there're 3 types of collectable POWER UPS:";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, powerText,true));
                    break;
                case 5:
                    NewCaseProtocol();
                    redPill.SetActive(true);
                    redTextGameObject.SetActive(true);
                    Invoke("SetDone",1f);
                    break;
                case 6:
                    NewCaseProtocol();
                    greenTextGameObject.SetActive(true);
                    greenPill.SetActive(true);
                    Invoke("SetDone",1f);
                    break;
                case 7:
                    NewCaseProtocol();
                    bluePill.SetActive(true);
                    blueTextGameObject.SetActive(true);
                    Invoke("SetDone",1f);
                    break;
                case 8:
                    NewCaseProtocol();
                    pressAnyKeyText.text = "Click anywhere to finish the tutorial";
                    pressAnyKeyToContinue.StartBlinking();
                    np.isAbleToSkip = true;
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

    IEnumerator StartTypeWritter(string passedValue, TextMeshProUGUI textTarget, bool finalResult)
    {
        for (int i = 0; i < passedValue.Length; i++)
        {
            
            TypeWritter(passedValue, i, textTarget);
            yield return new WaitForSeconds(0.05f);
        }

        _finalText = "";
        _isDone = finalResult;
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
        mainText.text = "";
        playerTextGameObject.SetActive(false);
        fakePlayer.SetActive(false);
        tilterTextGameObject.SetActive(false);
        hearts.SetActive(false);
        gHearts.SetActive(false);
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

    public void SetDone()
    {
        _isDone = true;
    }
    
    
    
}
