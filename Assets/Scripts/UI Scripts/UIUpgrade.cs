using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpgrade : MonoBehaviour {

	private GameObject parent; 
	public GameObject gem;

	void Awake()
	{

		for (int i = 0; i < Inventory.inventory.Count; i++){

			Gem temp = Inventory.inventory [i];

			parent = GameObject.Find ("Slot " + i);
			gem.GetComponent<UnityEngine.UI.Image> ().color = get_color (temp);
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = temp.getGrade().ToString();
			GameObject toinstance = Instantiate (gem,parent.transform,false) as GameObject;
		}

	}

	Color get_color (Gem temp) {
		switch (temp.getElement ()) {
		case 'F':
			return Color.red;
		case 'W':
			return Color.blue;
		case 'A':
			return Color.cyan;
		case 'E':
			return new Color(0.855f,0.388f,0.086f,1.0f);
		default:
			return Color.gray;
		}
	}

	public void add_gem_to_inventory (char element, int grade) {

		Gem newgem = new Gem (element, grade);
		if (Inventory.inventory.Count < 26) {
			Inventory.inventory.Add (newgem);
			int temp = InventoryCheck ();
			parent = GameObject.Find ("Slot " + temp);
			gem.GetComponent<UnityEngine.UI.Image> ().color = get_color(newgem);
			gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = newgem.getGrade().ToString ();
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

	public void refresh() {
		Awake ();
	}
}
