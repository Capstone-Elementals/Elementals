﻿/*	Author: Powered by Coffee
 * 	Description: Water Level script
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : BoardManager 
{

	protected override void Path(GameObject[] tileArray)
	{	
		
//		List<int> startpos = new List<int>();
//		for(int i = (columns * rows) - 1; i > ((columns * rows) - columns) - 1; i--){
//			startpos.Add(i);
//		}
//		int[] startPosArray = startpos.ToArray ();
//		base.RandomPath (startPosArray [Random.Range (0, startPosArray.Length)], 0, false, 2);
		base.RandomPath (Random.Range(0, columns), 2, false,0);
	}

	public new void SetupScene()
	{
//		BoardSetup();
//		Path(floorTiles);
		base.SetupScene();
	} 
}
