using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour {
	GameObject collected;
	GameObject total;
	// Use this for initialization
	void Start () {
		collected = GameObject.FindGameObjectWithTag ("FinishEssence");
		total = GameObject.FindGameObjectWithTag ("FinishTotal");
		collected.GetComponentInChildren<UnityEngine.UI.Text> ().text = Inventory.tempEssence.ToString ();
		total.GetComponentInChildren<UnityEngine.UI.Text> ().text = Inventory.essence.ToString ();
		Inventory.tempEssence = 0;
	}
}
