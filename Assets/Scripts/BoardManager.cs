using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.


public class BoardManager : MonoBehaviour
{
    // Using Serializable allows us to embed a class with sub properties in the inspector.
    [Serializable]
    public class Count
    {
        public int minimum;             //Minimum value for our Count class.
        public int maximum;             //Maximum value for our Count class.


        //Assignment constructor.
        public Count(int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }


    public int columns = 8;                                         //Number of columns in our game board.
    public int rows = 8;                                            //Number of rows in our game board.
    public GameObject exit;                                         //Prefab to spawn for exit.
    public GameObject[] floorTiles;                                 //Array of floor prefabs.
    public GameObject[] e1Tiles;                                  
    public GameObject[] e2Tiles;
    public GameObject[] e3Tiles;
    public GameObject[] e4Tiles;


    private Transform boardHolder;                                  //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>();   //A list of possible locations to place tiles.
    private List<GameObject> objects = new List<GameObject>();

    //Clears our list gridPositions and prepares it to generate a new board.
    void InitialiseList()
    {
        //Clear our list gridPositions.
        gridPositions.Clear();

        //Loop through x axis (columns).
        for (int x = 0; x < ( 7 *rows) ; x++)
        {
            //Within each column, loop through y axis (rows).
            for (int y = 0; y < ( 6 * columns); y++)
            {
                //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }
    }


    //Sets up the outer walls and floor (background) of the game board.
    void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = 0; x < ( 7 *rows) ; x = x + 7)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = 0; y < ( 6 *columns) ; y = y + 6)
            {
                //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

             

                //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                GameObject instance =
                    Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                instance.transform.SetParent(boardHolder);
                objects.Add(instance);
            }
        }
    }
    void Path(GameObject[] tileArray)
    {
        int pos = Random.Range(0, columns);
        int prevdir = 0;
        bool gooddir = false;
        for (int y = pos; 0 <= y && y < rows * columns;)
        {
            GameObject tileChoice = e4Tiles[Random.Range(0, e4Tiles.Length)];
            GameObject instance = Instantiate(tileChoice, new Vector3(objects[y].transform.position.x, objects[y].transform.position.y, objects[y].transform.position.z), Quaternion.identity) as GameObject;
            Destroy(objects[y]);
            instance.transform.SetParent(boardHolder);
            objects.Add(instance);
            while(gooddir == false)
            {
                int dir = Random.Range(0, 4);
                switch (dir)
                {
                    case 0:
                        if (prevdir == 0 || (y - columns) < 0)
                        {
                            gooddir = false;
                        }
                        else
                        {
                            y = y - columns;
                            gooddir = true;
                        }
                        break;
                    case 1:
                        if (prevdir == 1 || (y / columns) != 0)
                        {
                            gooddir = false;
                        }
                        else
                        {
                            y = y + 1;
                            gooddir = true;
                        }
                        break;
                    case 2:
                        if (prevdir == 2)
                        {
                            gooddir = false;
                        }
                        else
                        {
                            y = y + columns;
                            gooddir = true;
                        }
                        break;
                    case 3:
                        if (prevdir == 3 || (y / columns) != 0 || ( y - 1 ) < 0)
                        {
                            y = y - 1;
                            gooddir = true;
                        }
                        break;
                    default:
                        break;
                }
            }
            gooddir = false;
            
        }
        
    }
    public void SetupScene(int level)
    {
        BoardSetup();
        InitialiseList();
        Path(floorTiles);
    }
}
