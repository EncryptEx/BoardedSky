using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksBuilding : MonoBehaviour
{
    public int cols = 4;

    public int rows = 2;

    public GameObject brick;
        // Start is called before the first frame update
    void Start()
    {

        var distCols = 20 / cols;
        var distRows = 4 / rows;
        //ArrayList brickPositions;
        for (int r = 0; r < rows; r++)
        {
           for (int i = 0; i < cols; i++)
           {
               //brickPositions.Add(new Vector3(distCols * i, 0, distRows * i));
               var brickPos = new Vector3(distCols * i - 22, 1, distRows * r);
               var brickInstance = Instantiate(brick);
               brickInstance.transform.position = brickPos;
           } 
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
