using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	public static int difficulty;
	// Use this for initialization
	public void difficultyNum(int diffNum)
	{
		difficulty = diffNum;
	}
}
