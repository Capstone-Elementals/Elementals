using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCraft : MonoBehaviour {

	private GameObject parent; 
	public GameObject gem;


	int InventoryCheck () {
	
		for (int i = 0; i <= 24; i++) {
		
			parent = GameObject.Find ("Slot " + i);
			int child = parent.transform.childCount;
			if (child == 0) {
				return i;
			}
		}
		return -1;
	}

	void Awake()
	{

	}

	public void CreateFireGem (){

		//if (Inventory.essence > 15) {
			Gem newgem = new Gem ('F', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
			gem.GetComponent<UnityEngine.UI.Image> ().color = Color.red;
		    gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
		    GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
		//}

	}

	public void CreateWaterGem (){

		//if (Inventory.essence > 15) {
			Gem newgem = new Gem ('W', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
			gem.GetComponent<UnityEngine.UI.Image> ().color = new Color(0.0f,0.498f,1.0f,1.0f);
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
	//	}

	}

	public void CreateAirGem (){

		//if (Inventory.essence > 15) {
			Gem newgem = new Gem ('A', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
		gem.GetComponent<UnityEngine.UI.Image> ().color = new Color(0.294f,0.984f,0.953f);
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
	//	}
		
	}

	public void CreatEarthGem (){

		//if (Inventory.essence > 15) {
			Gem newgem = new Gem ('A', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
			gem.GetComponent<UnityEngine.UI.Image> ().color = new Color(0.855f,0.388f,0.086f,1.0f);
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
		//}

	}

	//Note: first check inventory slots, if childrens are null then add the object created to that slot as a child
	//      created object is a gem where it has an image, a grade and script (prefab)
	// 
}
