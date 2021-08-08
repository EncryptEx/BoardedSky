using UnityEngine;

public class WinSystem : MonoBehaviour
{
    public BricksBuilding bb;
    public LivesManager lm;
    private AudioManager am;
    public NitroManager nm;
    public ActionsLogger al;
    public Points p;

    private void Start()
    {
        bb = GameObject.Find("SpawnBricks").GetComponent<BricksBuilding>();
        am = AudioManager.Instance;
    }

    public void CheckForExistingBricks()
    {
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

            
        }
    }
}