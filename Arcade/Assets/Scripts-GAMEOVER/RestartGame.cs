using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void RestartEntireGame()
    {
        /*first, destroy all Don't destroy on load elements to make sure all resets correctly.
        ==== LIST OF OBLIGATORY: ====
        - Variables Saver
        - SoundSystem   
        - ui 
        - PointsSystem
        - DifficultyBrickSaver
        - GameOverSystem
        - GameOverText
        - CredentialsManager
        
        ==== LIST OF OPTIONALS: ==== (depending of what the user clicks or uses)
        none at the moment. this section could be useful for future :)
        
        now delete all the gameobjects before changing from scene. 
        */
        var variablesaver = GameObject.Find("Variables Saver");
        var soundsys = GameObject.Find("SoundSystem");
        var ui = GameObject.Find("ui");
        var points = GameObject.Find("PointsSystem");
        var diff = GameObject.Find("DifficultyBrickSaver");
        var go = GameObject.Find("GameOverSystem");
        var got = GameObject.Find("GameOverText");
        var pass = GameObject.Find("CredentialsManager");
        
        Destroy(variablesaver);
        Destroy(soundsys);
        Destroy(ui);
        Destroy(points);
        Destroy(diff);
        Destroy(go);
        Destroy(got);
        Destroy(pass);

        // now we're ready to change from scenes. 
        SceneManager.LoadScene(0);
    }
}
