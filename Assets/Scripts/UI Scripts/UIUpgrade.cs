using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpgrade : MonoBehaviour {

	private GameObject parent; 
	public GameObject gem;

	void Awake ()
	{
		for (int i = 0; i < Inventory.inventory.Count; i++) {
			Gem temp = Inventory.inventory [i];
			parent = GameObject.Find ("Slot " + i);
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
	}

	void InitGem (Gem temp)
	{
		switch (temp.getElement ()) {
		case 'F':
			gem.GetComponent<UnityEngine.UI.Image> ().color = Color.red;
			break;
		case 'W':
			gem.GetComponent<UnityEngine.UI.Image> ().color = Color.blue;
			break;
		case 'A':
			gem.GetComponent<UnityEngine.UI.Image> ().color = Color.cyan;
			break;
		case 'E':
			gem.GetComponent<UnityEngine.UI.Image> ().color = new Color (0.855f, 0.388f, 0.086f, 1.0f);
			break;
		default:
			break;
		}
		gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = temp.getGrade ().ToString ();
		GameObject toinstance = Instantiate (gem, parent.transform, false) as GameObject;
	}
}
