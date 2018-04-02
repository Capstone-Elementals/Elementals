using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCraft : MonoBehaviour {

	private GameObject parent; 
	public GameObject gem;


	void Awake()
	{

		for (int i = 0; i < Inventory.inventory.Count; i++){

			Gem temp = Inventory.inventory [i];

			parent = GameObject.Find ("Slot " + i);
			switch (temp.getElement ()) {
			case 'F':
				gem.GetComponent<UnityEngine.UI.Image> ().color = Color.red;
				break;
			case 'W':
				gem.GetComponent<UnityEngine.UI.Image> ().color =  Color.blue;
				break;
			case 'A':
				gem.GetComponent<UnityEngine.UI.Image> ().color = Color.cyan;
				break;
			case 'E':
				gem.GetComponent<UnityEngine.UI.Image> ().color = new Color(0.855f,0.388f,0.086f,1.0f);
				break;
			default:
				break;
			}
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = temp.getGrade().ToString();
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;

			}

		}


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

	public void CreateFireGem (){

		if (Inventory.essence >= 0) {
			//Inventory.essence -= 15;
			Gem newgem = new Gem ('F', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
			gem.GetComponent<UnityEngine.UI.Image> ().color = Color.red;
		    gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
		    GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
		}

	}

	public void CreateWaterGem (){

		if (Inventory.essence >= 15) {
			Inventory.essence -= 15;
			Gem newgem = new Gem ('W', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);

		gem.GetComponent<UnityEngine.UI.Image> ().color =  Color.blue;
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
		}

	}

	public void CreateAirGem (){

		if (Inventory.essence >= 15) {
			Inventory.essence -= 15;
			Gem newgem = new Gem ('A', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
		gem.GetComponent<UnityEngine.UI.Image> ().color = Color.cyan;
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
		}
		
	}

	public void CreatEarthGem (){

		if (Inventory.essence >= 15) {
			Inventory.essence -= 15;
			Gem newgem = new Gem ('A', 1);
			if (Inventory.inventory.Count < 26) {
				Inventory.inventory.Add (newgem);
			}
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
			gem.GetComponent<UnityEngine.UI.Image> ().color = new Color(0.855f,0.388f,0.086f,1.0f);
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
		}

	}

}
