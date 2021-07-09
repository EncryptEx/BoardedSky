using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksBuilding : MonoBehaviour
{
    public int cols = 4;

    public int rows = 2;

    public GameObject brick;

    public BoxCollider col;
        // Start is called before the first frame update
    void Start()
    {

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
               var brickPos = new Vector3(x*3*i-22+col.size.x, 1, z*r+col.size.z);
               Debug.Log("brickpos "+i+"|"+r+brickPos);
               var brickInstance = Instantiate(brick);
               // brick creates the ref to the points system script.
               brickInstance.transform.position = brickPos;
           } 
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
