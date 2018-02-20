using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public static int level;
	public static int difficulty;
	public void LoadLevel(string name){
		Debug.Log ("Loading Level" + name);
		Application.LoadLevel (name);
	}
	public void levelNum(int levelNum){
		level = levelNum;
	}
	public void difficultyNum(int diffNum)
	{
		difficulty = diffNum;
	}
}
