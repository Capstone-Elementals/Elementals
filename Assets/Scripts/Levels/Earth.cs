/*	Author: Powered by Coffee
 * 	Description: Earth Level script
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : BoardManager {




	protected override void Path(GameObject[] tileArray)
	{
//		List<int> startpos = new List<int>();
//		for(int i = columns - 1; i < columns * rows; i+= rows){
//			startpos.Add(i);
//		}
//		int[] startPosArray = startpos.ToArray ();
//		base.RandomPath (startPosArray [Random.Range (0, startPosArray.Length)], 3, false, 1);
		base.RandomPath (Random.Range(0, columns), 2, false,0);
	}

	public new void SetupScene()
	{
//		BoardSetup();
//		Path(floorTiles);
		base.SetupScene();
	} 
}
