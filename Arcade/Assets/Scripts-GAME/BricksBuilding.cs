using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksBuilding : MonoBehaviour
{
    public int cols = 4;

    public int rows = 2;
    public bool debug = false;

    public GameObject brick;

    public BoxCollider col;
        // Start is called before the first frame update


    
    void Start()
    {
        Invoke("GenerateNewBricks",0);       
 
    }


    public void GenerateDelayedNewBricks()
    {
        Invoke("GenerateNewBricks",1f);
    }
    
    public void GenerateNewBricks()
    {
        //generate rows and cols.

        int randCols = UnityEngine.Random.Range(5, 8);
        int randRows = UnityEngine.Random.Range(3, 4);

        if (!debug)
        {
            cols = randCols;
            rows = randRows;
        }

        var distCols = 13 / cols;
        Debug.Log("distcols:"+distCols);
        
        var distRows = 8 / rows;
        Debug.Log("distrows:"+distRows);
        
        
        //add size of brick itself before calculating final brickpos
        var x = distCols;
        var z = distRows;
        
        //ArrayList brickPositions;
        for (int r = 0; r < rows; r++)
        {
            for (int i = 0; i < cols; i++)
            {
                //brickPositions.Add(new Vector3(distCols * i, 0, distRows * i));
                var brickPos = new Vector3(distCols*(i*1.2f)-22+col.size.x, 1, distRows*r+col.size.z);
                Debug.Log("brickpos "+i+"|"+r+brickPos);
                var brickInstance = Instantiate(brick);
                // brick creates the ref to the points system script.
                brickInstance.transform.position = brickPos;
            } 
        }
    }
}
