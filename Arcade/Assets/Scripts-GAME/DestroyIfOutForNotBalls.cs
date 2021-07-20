
using UnityEngine;

public class DestroyIfOutForNotBalls : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("gameover") && gameObject.name == "Walls")
        {
            Invoke("Remove",5);
        }
        else if (other.CompareTag("gameover")) //this means the objects is falling is not the ball itself (can be player, bricks...)
        {
            Destroy(gameObject);
        }
                
        }

        private void Remove()
        {
            Destroy(gameObject);
        }
}
