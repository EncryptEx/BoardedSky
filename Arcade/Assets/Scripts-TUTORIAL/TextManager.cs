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
    
    //case 3:
    private FakePlayerController _fpc;
    
    //case 4
    public GameObject gHearts;
    public GameObject goldenTextGameObject;
    [HideInInspector] public TextMeshProUGUI goldenUGUI;
    
    //case 5
    public GameObject pressAnyKeyGameObject;
    [HideInInspector] public BlinkTextForTutorial pressAnyKeyToContinueScript;
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
    private NitroSimulator _ns; 
    public GameObject nitro2;
    public GameObject nitro3;
    
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
    
    //case 10 - camera movement
    public CameraMove cm;

    
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
        pressAnyKeyToContinueScript = pressAnyKeyGameObject.GetComponent<BlinkTextForTutorial>();
        brickText1 = brickText1GameObject.GetComponent<TextMeshProUGUI>();
        brickText2 = brickText2GameObject.GetComponent<TextMeshProUGUI>();
        nitroText = nitroTextGameObject.GetComponent<TextMeshProUGUI>();
        powerText = powerUpTextGameObject.GetComponent<TextMeshProUGUI>();
        redText = redTextGameObject.GetComponent<TextMeshProUGUI>();
        blueText = blueTextGameObject.GetComponent<TextMeshProUGUI>();
        redText = redTextGameObject.GetComponent<TextMeshProUGUI>();
        pressAnyKeyText = pressAnyKeyToContinueScript.GetComponent<TextMeshProUGUI>();
        mainText = mainTextGameObject.GetComponent<TextMeshProUGUI>();
        pressAnyKeyToContinueScript = pressAnyKeyGameObject.GetComponent<BlinkTextForTutorial>();
        _fpc = fakePlayer.GetComponent<FakePlayerController>();
        _ns = nitro.GetComponent<NitroSimulator>();
        
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
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, tilterTextUGUI,true));
                    
                    break;
                case 3:// press WASD moment
                    NewCaseProtocol();
                    _fpc.isAbleToInvoke = true;
                    break;
                    
                case 4: //lives moment
                    _isDone = false;
                    _howManyDones++;
                    hearts.SetActive(true);
                    heartTextGameObject.SetActive(true);
                    textToWrite = "You have lives and you die when you reach 0.";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, heartTextUGUI,true));
                    break;
                case 5: // golden moment
                    NewCaseProtocol();
                    gHearts.SetActive(true);
                    goldenTextGameObject.SetActive(true);
                    textToWrite = "Extra lives are golden:";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, goldenUGUI,true));
                    break;
                case 6:
                    NewCaseProtocol();
                    pressAnyKeyText.text = "Click anywhere to continue";
                    pressAnyKeyToContinueScript.StartBlinking();
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
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, nitroText,true));
                    break;
                case 4:
                    NewCaseProtocol();
                    _ns.isAbleToNitro = true;
                    break;
                case 5:
                    NewCaseProtocol();
                    powerUpTextGameObject.SetActive(true);
                    textToWrite = "And finally, there're 3 types of collectable POWER UPS:";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, powerText,true));
                    break;
                case 6:
                    
                    _isDone = false;
                    _howManyDones++;
                    redPill.SetActive(true);
                    redTextGameObject.SetActive(true);
                    Invoke("SetDone",1f);
                    break;
                case 7:
                    NewCaseProtocol();
                    greenTextGameObject.SetActive(true);
                    greenPill.SetActive(true);
                    Invoke("SetDone",1f);
                    break;
                case 8:
                    NewCaseProtocol();
                    bluePill.SetActive(true);
                    blueTextGameObject.SetActive(true);
                    Invoke("SetDone",1f);
                    break;
                case 9:
                    NewCaseProtocol();
                    pressAnyKeyText.text = "Click anywhere to finish the tutorial";
                    pressAnyKeyToContinueScript.StartBlinking();
                    np.isAbleToSkip = true;
                    break;
                case 10:
                    np.isAbleToSkip = false;
                    NewCaseProtocol();
                    //remove all stuff from part 2-
                    brickText1GameObject.SetActive(false);
                    brickText2GameObject.SetActive(false);
                    nitro.SetActive(false);
                    nitroTextGameObject.SetActive(false);
                    powerUpTextGameObject.SetActive(false);
                    redPill.SetActive(false);
                    redTextGameObject.SetActive(false);
                    greenTextGameObject.SetActive(false);
                    greenPill.SetActive(false);
                    backgroundWall.SetActive(false);
                    bluePill.SetActive(false);
                    blueTextGameObject.SetActive(false);
                    pressAnyKeyGameObject.SetActive(false);
                    nitro2.SetActive(false);
                    nitro3.SetActive(false);
                    brickModel.SetActive(false);
                    hardBrickModel.SetActive(false);
                    //start function---
                    mainTextGameObject.SetActive(true);
                    backgroundWall.SetActive(true);
                    textToWrite = "Alright! Now you are prepared to put that in practice.\n" +
                                  "Let's go to the game...";
                    _coroutineSaver = StartCoroutine(StartTypeWritter(textToWrite, mainText,true));
                    break;
                case 11:
                    NewCaseProtocol();
                    mainTextGameObject.SetActive(false);
                    Invoke("SetDone",1.8f);
                    _isDone = true;
                    break;
                case 12:
                    _howManyDones++;
                    _isDone = false;
                    cm.StartMovingCamera(); 
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
        pressAnyKeyGameObject.SetActive(false);
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
