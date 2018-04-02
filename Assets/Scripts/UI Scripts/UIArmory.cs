using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArmory : MonoBehaviour {

	private GameObject parent; 
	public GameObject gem;
	void Awake()
	{

		for (int i = 0; i < Inventory.inventory.Count; i++){
			Gem temp = Inventory.inventory [i];
			parent = GameObject.Find ("Slot " + i);
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
		if (Inventory.playerWeapon1.getGem1 ().getElement() != 'N') {
			Gem temp = Inventory.playerWeapon1.getGem1();
			parent = GameObject.Find ("W1Slot 1");
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
		if (Inventory.playerWeapon1.getGem2 ().getElement() != 'N') {
			Gem temp = Inventory.playerWeapon1.getGem2();
			parent = GameObject.Find ("W1Slot 2");
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
		if (Inventory.playerWeapon1.getGem3 ().getElement() != 'N') {
			Gem temp = Inventory.playerWeapon1.getGem3();
			parent = GameObject.Find ("W1Slot 3");
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
		if (Inventory.playerWeapon2.getGem1 ().getElement() != 'N') {
			Gem temp = Inventory.playerWeapon2.getGem1();
			parent = GameObject.Find ("W2Slot 1");
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
		if (Inventory.playerWeapon2.getGem2 ().getElement() != 'N') {
			Gem temp = Inventory.playerWeapon2.getGem2();
			parent = GameObject.Find ("W2Slot 2");
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
		if (Inventory.playerWeapon2.getGem3 ().getElement() != 'N') {
			Gem temp = Inventory.playerWeapon2.getGem3();
			parent = GameObject.Find ("W2Slot 3");
			Transform tempChild = parent.transform.GetChild (0);
			Destroy (tempChild.gameObject);
			InitGem (temp);
		}
		if (Inventory.playerArmor.getGem1().getElement() != 'N') {
			Gem temp = Inventory.playerArmor.getGem1();
			parent = GameObject.Find ("A1Slot 1");
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

	// Update is called once per frame
	void FixedUpdate () {
//		GameObject gemSlot;
//		gemSlot = GameObject.Find ("W1Slot 1");
//		GameObject slot = gemSlot.transform.GetChild (0).gameObject;
//		if (slot.tag == "Gem") {
//			Debug.Log ("Adding Gem");
//			Inventory.playerWeapon1.setGem1 (new Gem (GemElement(slot.gameObject), 
//				System.Int32.Parse(slot.GetComponentInChildren<UnityEngine.UI.Text> ().text)));
//		}
	}
	char GemElement(GameObject temp)
	{
		if(temp.GetComponent<UnityEngine.UI.Image> ().color == Color.red)
		{
			return 'F';
		}
		if(temp.GetComponent<UnityEngine.UI.Image> ().color == Color.blue)
		{
			return 'W';
		}
		if(temp.GetComponent<UnityEngine.UI.Image> ().color == Color.cyan)
		{
			return 'A';
		}
		if(temp.GetComponent<UnityEngine.UI.Image> ().color == new Color (0.855f, 0.388f, 0.086f, 1.0f))
		{
			return 'E';
		}
		return 'N';
	}
}
