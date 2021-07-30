using UnityEngine;

public class Brick : MonoBehaviour
{
    public int brickDiff = 2;
    public GameObject brick;
    public GameObject brickbase;
    public Color OneHpColor;
    public int count;

    [Tooltip("Power UP SCRIPT")] public PowerUpScript Pw;

    public DifficultyBrickSaver bd;

    private Points po;

    private float randomP;

    // Start is called before the first frame update
    private void Start()
    {
        Pw = GameObject.Find("PowerUpsManager").GetComponent<PowerUpScript>();
        bd = GameObject.Find("DifficultyBrickSaver").GetComponent<DifficultyBrickSaver>();
        Debug.Log("found bd:" + bd);
        Debug.Log("found pw:" + Pw);

        var tobrickDiff = bd.diff;
        Debug.Log(tobrickDiff);
        //find difficulty set ( 3 modes, 0,1,2)
        if (tobrickDiff == 1)
        {
            var random = Random.Range(1, 10);
            if (random <= 3) brickDiff = 1;
        }

        if (tobrickDiff == 0) brickDiff = 1;

        if (tobrickDiff == 2) brickDiff = 2;
        //make sure clone is enabled
        brick.gameObject.SetActive(true);
        randomP = UnityEngine.Random.Range(1f, 10f);
    }

// Update is called once per frame
    private void Update()
    {
        ///optimization would be great to earn FPS
        if (brickDiff == 1)
        {
            //future feedback to the user to make him realise has damaged a block
            var brickrenderer = brickbase.GetComponent<Renderer>();
            brickrenderer.material.SetColor("_Color",
                OneHpColor);
        }

        if (brickDiff <= 0)
        {
            //make disssapear when braking it.
            //possibility to create a power UP
            Debug.Log("my rand was " + randomP);
            if (randomP > 8f)
            {
                //throw powerUP
                Debug.Log("power UP TRIGGER 1ST");
                Pw.SpawnNewPowerUp(transform.position);
            }

            //Debug.Log("BRICK DESTROYED");
            Destroy(brick);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("COLLISION IN"+gameObject.name);
        if (other.gameObject.CompareTag("projectile")) //substact 1 live from brick.
            brickDiff--;
    }
}