using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{
	public static int level;
	public void LoadLevel(string name)
	{
		Debug.Log ("Loading Level" + name);
		Inventory.tempEssence = 0;
		Application.LoadLevel (name);
	}
	public void levelNum(int levelNum)
	{
		level = levelNum;
	}
	public void WorldBack()
	{
		Inventory.essence -= Inventory.tempEssence;
		Inventory.tempEssence = 0;
		Application.LoadLevel ("Hub2");
	}

}
