using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : BoardManager {

	protected override void Path(GameObject[] tileArray)
	{
		List<int> startpos = new List<int>();
		for(int i = 0; i < columns; i++){
			startpos.Add(((columns * rows) - 1) - i);
		}
		int[] startPosArray = startpos.ToArray ();
		base.RandomPath (startPosArray [Random.Range (0, startPosArray.Length)], 1, false, 1);
	}

	public new void SetupScene()
	{
		BoardSetup();
		InitialiseList();
		Path(floorTiles);
	} 
}
