using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : BoardManager {




	protected override void Path(GameObject[] tileArray)
	{
		List<int> startpos = new List<int>();
		for(int i = 0; i < rows; i++){
			startpos.Add((columns - 1) + (i * columns));
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
