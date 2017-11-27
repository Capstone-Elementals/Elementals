using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : BoardManager {

	protected override void Path(GameObject[] tileArray)
	{
		int startpos = Random.Range (0, rows) * columns;
		base.RandomPath (startpos, 1, false, 3);
	}

	public new void SetupScene()
	{
		BoardSetup();
		InitialiseList();
		Path(floorTiles);
	} 
}
