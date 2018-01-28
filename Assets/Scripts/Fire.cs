using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : BoardManager {

	protected override void Path(GameObject[] tileArray)
	{
		base.RandomPath (Random.Range(0, columns), 2, false,0);
	}

	public new void SetupScene()
	{
		BoardSetup();
		Path(floorTiles);
	} 
}
