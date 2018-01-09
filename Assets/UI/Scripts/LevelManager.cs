using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Loading Level" + name);
		Application.LoadLevel (name);
	}


}
