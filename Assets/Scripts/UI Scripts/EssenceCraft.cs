using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceCraft : MonoBehaviour {
	GameObject[] gems;
	// Use this for initialization
	void Start () {
		gems = GameObject.FindGameObjectsWithTag ("Essence");
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < gems.Length; i++) {
			gems [i].GetComponent<UnityEngine.UI.Text> ().text = Inventory.essence.ToString () + "/15";
		}
	}
}
