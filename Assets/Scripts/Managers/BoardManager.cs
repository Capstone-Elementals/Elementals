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
	public int scalex = 7;//x-scale of each tile
	public int scaley = 6; //y-scale of each tile
	public GameObject boss;//Prefab to spawn for boss tile.
    public GameObject[] floorTiles;//Array of All tiles.
    public GameObject[] e1Tiles;//Array of tiles with 1 entrance                                  
	public GameObject[] e2Tiles;//Array of tiles with 2 entrance
	public GameObject[] e3Tiles;//Array of tiles with 3 entrance
	public GameObject[] e4Tiles;//Array of tiles with 4 entrance
	public GameObject[] enemies;
	public Count enemiesCount = new Count (1, 10);
	public GameObject player;//Prefab of player
	public GameObject edgeV;
	public GameObject edgeH;

    private Transform boardHolder;//A variable to store a reference to the transform of our Board object.
    private List<GameObject> objects = new List<GameObject>();//List of all objects in Board
	protected List<int> RandomPosRecord = new List<int>();
    //Sets up the outer walls and floor (background) of the game board.
    protected void BoardSetup()
    {
        //Instantiate Board and set boardHolder to its transform.
        boardHolder = new GameObject("Board").transform;

        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = 0; x < ( scalex *rows) ; x = x + scalex)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = 0; y < ( scaley *columns) ; y = y + scaley)
            {
				if (x == 0) {
					GameObject edge = edgeV;
					Instantiate (edge, new Vector3 (x - (scalex / 2), y, 0f), Quaternion.identity);
				}
				if(x == (scalex * rows) - scalex){
					GameObject edge = edgeV;
					Instantiate (edge, new Vector3 (x + (scalex / 2), y, 0f), Quaternion.identity);
				}
				if(y == 0){
					GameObject edge = edgeH;
					Instantiate (edge, new Vector3 (x, y - (scaley/2), 0f), Quaternion.identity);
				}
				if (y == (scaley * columns) - scaley) {
					GameObject edge = edgeH;
					Instantiate (edge, new Vector3 (x, y + (scaley/2), 0f), Quaternion.identity);
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
	protected virtual void Path(GameObject[] tileArray)
    {
		
    }
    public void SetupScene()
    {
        BoardSetup();
        Path(floorTiles);
		ObjectRandomPos (enemies, enemiesCount.minimum, enemiesCount.maximum);
    }
	protected void ObjectRandomPos (GameObject[] objectarray, int min, int max)
	{
		int limit = Random.Range (min, max + 1);
		for (int i = 0; i < limit; i++) {
			GameObject objecttobeinstantiated = objectarray[Random.Range(0,objectarray.Length)];
			Vector3 randompos = RandomPos();
			Instantiate(objecttobeinstantiated, randompos, Quaternion.identity);
		}
	}
	protected Vector3 RandomPos()
	{
		int randomint = Random.Range (0, objects.Count);
		while (true) {
				if (RandomPosRecord.Contains(randomint) == true) {
					randomint = Random.Range (0, objects.Count);
				} else {
					break;
				}	
		}
		RandomPosRecord.Add (randomint);
		Transform temp = objects[randomint].transform;
		Vector3 tempVectpor = new Vector3 (temp.position.x, temp.position.y, 0f);
		return tempVectpor;
	}
	protected void PlaceTile (int y)
	{
		GameObject tileChoice = e4Tiles [Random.Range (0, e4Tiles.Length)];
		GameObject instance = Instantiate (tileChoice, new Vector3 (objects [y].transform.position.x, objects [y].transform.position.y, objects [y].transform.position.z), Quaternion.identity) as GameObject;
		Destroy (objects [y]);
		instance.transform.SetParent (boardHolder);
		objects.Add (instance);
	}
	protected void RandomPath (int pos, int prevdir, bool gooddir, int invalid)
	{	
		List<int> traversedpath = new List<int>();
		Instantiate (player, new Vector3 (objects [pos].transform.position.x, objects [pos].transform.position.y, objects [pos].transform.position.z), Quaternion.identity);
		for (int y = pos; 0 <= y && y < rows * columns;) {
			PlaceTile (y);
			traversedpath.Add (y);
			while (gooddir == false) {
				int dir = Random.Range (0, 100);
				switch ((dir % 4)) {
				case 0://Move Left
					if ((prevdir % 4) == 2 || (y - columns) < 0 || invalid == 0) {
						gooddir = false;
					}
					else {
						if (traversedpath.Contains(y - columns)) {
							gooddir = false;
							break;
						}
						y = y - columns;
						prevdir = 0;
						gooddir = true;
					}
					break;
				case 1://Move Up
					if ((prevdir % 4) == 3 || ((y + 1) % columns) == 0 || invalid == 1) {
						gooddir = false;
					}
					else {
						if (traversedpath.Contains(y + 1)) {
							gooddir = false;
							break;
						}
						y = y + 1;
						prevdir = 1;
						gooddir = true;
					}
					break;
				case 2://Move Right
					if ((prevdir % 4) == 0 || invalid == 2) {
						gooddir = false;
					}
					else {
						if (traversedpath.Contains(y + columns)) {
							gooddir = false;
							break;
						}
						y = y + columns;
						prevdir = 2;
						gooddir = true;
					}
					break;
				case 3://Move Down
					if ((prevdir % 4) == 1 || ((y - 1) % columns) == columns - 1 || (y - 1) < 0 || invalid == 3) {
						gooddir = false;
					}
					else {
						if (traversedpath.Contains(y - 1)) {
							gooddir = false;
							break;
						}
						y = y - 1;
						prevdir = 3;
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
}
