using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	bool isSlotEmpty(){

		if (Inventory.inventory.Count == 0) {
			return true;
		} else {
			return false;
		}
	}
	bool isSlotFull (){

		if (Inventory.inventory.Count == 25) {
			return true;
		} else {
			return false;
		}
	}

	void fireGems (){

		if (!isSlotFull()) {
			
		}
	}
	void airGems (){
	}
	void waterGems(){
	}
	void earthGems(){
	}
}
