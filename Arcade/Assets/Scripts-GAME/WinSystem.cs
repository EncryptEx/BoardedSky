using UnityEngine;

public class WinSystem : MonoBehaviour
{
    public BricksBuilding bb;
    public LivesManager lm;
    private AudioManager am;
    public NitroManager nm;
    public ActionsLogger al;
    public ProjectileBehaviour pb;
    private float _velocityMultipier;
    public Points p;

    private void Start()
    {
        bb = GameObject.Find("SpawnBricks").GetComponent<BricksBuilding>();
        am = AudioManager.Instance;
        _velocityMultipier = 1f;
    }

    public void CheckForExistingBricks()
    {
        pb = GameObject.FindWithTag("projectile").GetComponent<ProjectileBehaviour>();
        Debug.Log("Checking if aren't bricks,");
        if (GameObject.FindGameObjectsWithTag("brick").Length == 1
        ) //why 1? bc the checking is done before removing the last one
        {
            Debug.Log("No bricks!");
            //need to regenerate new blocks until player dies

            //delayed!!! important to make sure ball doesn't gets shoked. (can happen)
            bb.GenerateDelayedNewBricks();
            //add life to player as a reward 
            if (lm.lives <= 5)
            {
                lm.lives++;
                al.WriteOnLogText("+1 life");
                am.PlayOneMoreLife();
            }
            else
            {
                Debug.Log("user has 6 lifes. To much.");
                //as the player has 6 lifes, now it will have 1000 extra points for evey brick full break.  
                al.WriteOnLogText("+1000 points" +
                                  "+ Nitro");
                nm.EnableNitro();
                am.PlayOneMoreLife();
                p.Updatecounter(1000);
            }
            // to make it more difficult, now every time user gets more points but has more velocity. 
            _velocityMultipier += 0.2f;
            pb.IncreaseBallSpeed(_velocityMultipier);
        }
    }
}