/*	Author: Powered By Coffee 2017-2018
 *	Lead Developer: Ahmed Shamiss 
 *	Description: This object generates each level. Procedural generation of level and
 *  placement of objects and enemies is done by this script. 
 * 	There is a function for each step to fully create the level.
 * 	BoardSetup
 * 	Path
 *	ObjectRandomPos
 *
*/


using UnityEngine;
using System;
using System.Collections.Generic;       //Lists
using Random = UnityEngine.Random;      //Unity engine Random function


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

    public int columns = 8;//Number of columns in our game board.
    public int rows = 8;//Number of rows in our game board.
	public int scaleX = 7;//x-scale of each tile
	public int scaleY = 6; //y-scale of each tile
	public GameObject boss;//Prefab to spawn for boss tile.
    public GameObject[] floorTiles;//Array of All tiles.
	public GameObject[] e4Tiles;//Array of tiles with 4 entrance
	public GameObject[] enemies;//Array of enemies to be used to level
	private Count enemiesCount = new Count (1, 10); // max and min of amount of enemies to be placed in level
	public GameObject player;//Prefab of player
	public GameObject edgeV;//Prefab for vertical edge of level
	public GameObject edgeH;//Prefab for horizontal edge of level
	public GameObject background;//Prefab for background of level
    private Transform boardHolder;//A variable to store a reference to the transform of our Board object.
	private Transform edgeHolder;//A variable to store a reference to the transform of our Edge object.
	private Transform objectHolder;//A variable to store a reference to the transform of our objects.
    private List<GameObject> objects = new List<GameObject>();//List of all objects in Board
	protected List<int> randomPosRecord = new List<int>();//List of positions used to place enemies or items.

	//Getter to get enemy count for this object
	public Count GetEnemyCount()
	{
		return this.enemiesCount;
	}
	//Setter to set the enemy count
	public void SetEnemyCount(int min, int max)
	{
		this.enemiesCount.minimum = min;
		this.enemiesCount.maximum = max;
	}

	/*	Sets up the outer walls and background of the level.
	* 	Places Random tiles inside the outer walls
	*/
    protected void BoardSetup()
    {
        //Used to keep Scene hierarchy clean
        boardHolder = new GameObject("Board").transform;
		edgeHolder = new GameObject ("Edge").transform;
		objectHolder = new GameObject ("Objects").transform;
        for (int x = 0; x < ( scaleX * rows) ; x = x + scaleX)
        {
            for (int y = 0; y < ( scaleY * columns) ; y = y + scaleY)
            {
				//Place Borders
				if (x == 0) 
				{
					GameObject edge = edgeV;
					GameObject edgeInstance = Instantiate (edge, new Vector3 (x - (scaleX / 2) + 0.5f, y, 0f), Quaternion.identity) as GameObject;
					edgeInstance.transform.SetParent(edgeHolder);
				}
				if(x == (scaleX * rows) - scaleX)
				{
					GameObject edge = edgeV;
					GameObject edgeInstance = Instantiate (edge, new Vector3 (x + (scaleX / 2) - 0.5f, y, 0f), Quaternion.identity) as GameObject;
					edgeInstance.transform.SetParent(edgeHolder);
				}
				if(y == 0)
				{
					GameObject edge = edgeH;
					GameObject edgeInstance = Instantiate (edge, new Vector3 (x, y - (scaleY / 2) + 0.5f, 0f), Quaternion.identity) as GameObject;
					edgeInstance.transform.SetParent(edgeHolder);
				}
				if (y == (scaleY * columns) - scaleY) 
				{
					GameObject edge = edgeH;
					GameObject edgeInstance = Instantiate (edge, new Vector3 (x, y + (scaleY / 2) - 0.5f, 0f), Quaternion.identity) as GameObject;
					edgeInstance.transform.SetParent(edgeHolder);
				}
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
	//Create the path for the player from start to finish, to be used by each individual level
	protected virtual void Path(GameObject[] tileArray)
    {
		
    }
	//Function called when unity enters the scene
    public void SetupScene()
    {
        BoardSetup();
        Path(floorTiles);
		ObjectRandomPosition (enemies, enemiesCount.minimum, enemiesCount.maximum);
		InitBackground ();
    }
	//Instantiates the background of the level
	protected void InitBackground()
	{
		GameObject backgroundSetter = background;
		Instantiate (backgroundSetter, new Vector3 (((float)(rows*scaleX)/2) - (scaleX/2), ((float)(columns*scaleY/2)) - (scaleY/2), 0), Quaternion.identity);
	}
	//Places an object at a random position
	protected void ObjectRandomPosition (GameObject[] objectArray, int min, int max)
	{
		int limit = Random.Range (min, max + 1);
		for (int i = 0; i < limit; i++) 
		{
			GameObject objectToBeInstantiated = objectArray[Random.Range(0,objectArray.Length)];
			Vector3 randomPosition = RandomPosition();
			GameObject objectInstance = Instantiate(objectToBeInstantiated, randomPosition, Quaternion.identity) as GameObject;
			objectInstance.transform.SetParent(objectHolder);
		}
	}
	//Selects a random Vector3 position and returns it
	protected Vector3 RandomPosition ()
	{
		int randomInt = Random.Range (0, objects.Count);
		while (true)
		{
			if (randomPosRecord.Contains(randomInt) == true) 
			{
				randomInt = Random.Range (0, objects.Count);
			} 
			else 
			{
				break;
			}	
		}
		randomPosRecord.Add (randomInt);
		Transform temp = objects[randomInt].transform;
		Vector3 tempVectPosition = new Vector3 (temp.position.x + Random.Range (-scaleX / 4, scaleX / 4), 
			temp.position.y + Random.Range (-scaleY / 4, scaleY / 4), 0f);
		return tempVectPosition;
	}
	//Places a game tile into the scene
	protected void PlaceTile (int y)
	{
		GameObject tileChoice = e4Tiles [Random.Range (0, e4Tiles.Length)];
		GameObject instance = Instantiate (tileChoice, new Vector3 (objects [y].transform.position.x, 
			objects [y].transform.position.y, objects [y].transform.position.z), Quaternion.identity) as GameObject;
		Destroy (objects [y]);
		instance.transform.SetParent (boardHolder);
		objects.Add (instance);
	}
	/*	Creates a random path for the player
	 * 	Takes the initial starting position pos 
	 * 	The previous direction used in the algorithm ( this is mainly used for the initial direction when starting the game)
	 * 	gooddir used to indicate if the direction is a valid direction or not.
	 * 	invalid indicates a direction that should never be taken. 
	 * 	These inputs are used to start the algorithm going aswell as allowing method to be able to move in different directions
	 * 	depending on what was input. e.g. If we want the algorithm to move from left to right we ensure that it can never go
	 * 	left and vice versa.
	 * 	The algorithm selects a random number in checks using ifs whether that direction is valid or not, if it is not we try again.
	 * 	The algorithm runs until we have reached the edge of the game board.
	 * 
	*/
	protected void RandomPath (int position, int previousDirection, bool goodDirection, int invalid)
	{	
		List<int> traversedPath = new List<int>();
		Instantiate (player, new Vector3 (objects [position].transform.position.x, objects [position].transform.position.y, 
			objects [position].transform.position.z), Quaternion.identity);
		for (int y = position; 0 <= y && y < rows * columns;) 
		{
			PlaceTile (y);
			traversedPath.Add (y);
			while (goodDirection == false) 
			{
				int direction = Random.Range (0, 100);
				switch ((direction % 4)) 
				{
				case 0://Move Left
					if ((previousDirection % 4) == 2 || (y - columns) < 0 || invalid == 0)
					{
						goodDirection = false;
					}
					else 
					{
						if (traversedPath.Contains(y - columns)) 
						{
							goodDirection = false;
							break;
						}
						y = y - columns;
						previousDirection = 0;
						goodDirection = true;
					}
					break;
				case 1://Move Up
					if ((previousDirection % 4) == 3 || ((y + 1) % columns) == 0 || invalid == 1) 
					{
						goodDirection = false;
					}
					else 
					{
						if (traversedPath.Contains(y + 1)) 
						{
							goodDirection = false;
							break;
						}
						y = y + 1;
						previousDirection = 1;
						goodDirection = true;
					}
					break;
				case 2://Move Right
					if ((previousDirection % 4) == 0 || invalid == 2) 
					{
						goodDirection = false;
					}
					else 
					{
						if (traversedPath.Contains(y + columns)) 
						{
							goodDirection = false;
							break;
						}
						y = y + columns;
						previousDirection = 2;
						goodDirection = true;
					}
					break;
				case 3://Move Down
					if ((previousDirection % 4) == 1 || ((y - 1) % columns) == columns - 1 || (y - 1) < 0 || invalid == 3) 
					{
						goodDirection = false;
					}
					else 
					{
						if (traversedPath.Contains(y - 1)) 
						{
							goodDirection = false;
							break;
						}
						y = y - 1;
						previousDirection = 3;
						goodDirection = true;
					}
					break;
				default:
					break;
				}
			}
			goodDirection = false;
		}
	}
}
