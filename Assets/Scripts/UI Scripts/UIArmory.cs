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
			parent = GameObject.Find ("ASlot 1");
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
			gem.GetComponent<UnityEngine.UI.Image> ().color = Inventory.brown;
			break;
		default:
			break;
		}
		gem.GetComponentInChildren<UnityEngine.UI.Text> ().text = temp.getGrade ().ToString ();
		GameObject toinstance = Instantiate (gem, parent.transform, false) as GameObject;
	}

	public void OnSceneExit()
	{
		GameObject gemSlot;
		Gem newGem;
		gemSlot = GameObject.Find ("W1Slot 1");
		GameObject slot = gemSlot.transform.GetChild (0).gameObject;
		if (slot.tag == "Gem") {
			newGem = new Gem (GemElement (slot.gameObject), System.Int32.Parse (slot.GetComponentInChildren<UnityEngine.UI.Text> ().text));
			Inventory.playerWeapon1.setGem1 (newGem);
			Inventory.inventory.RemoveAt(FindGem (newGem));
		} else {
			Inventory.playerWeapon1.setGem1 (new Gem ());
		}
		gemSlot = GameObject.Find ("W1Slot 2");
		slot = gemSlot.transform.GetChild (0).gameObject;
		if (slot.tag == "Gem") {
			Inventory.playerWeapon1.setGem2 (new Gem (GemElement(slot.gameObject), 
				System.Int32.Parse(slot.GetComponentInChildren<UnityEngine.UI.Text> ().text)));
		}
		else {
			Inventory.playerWeapon1.setGem2 (new Gem ());
		}
		gemSlot = GameObject.Find ("W1Slot 3");
		slot = gemSlot.transform.GetChild (0).gameObject;
		if (slot.tag == "Gem") {
			Inventory.playerWeapon1.setGem3 (new Gem (GemElement(slot.gameObject), 
				System.Int32.Parse(slot.GetComponentInChildren<UnityEngine.UI.Text> ().text)));
		}
		else {
			Inventory.playerWeapon1.setGem3 (new Gem ());
		}
		gemSlot = GameObject.Find ("W2Slot 1");
		slot = gemSlot.transform.GetChild (0).gameObject;
		if (slot.tag == "Gem") {
			Inventory.playerWeapon2.setGem1 (new Gem (GemElement(slot.gameObject), 
				System.Int32.Parse(slot.GetComponentInChildren<UnityEngine.UI.Text> ().text)));
		}
		else {
			Inventory.playerWeapon2.setGem1 (new Gem ());
		}
		gemSlot = GameObject.Find ("W2Slot 2");
		slot = gemSlot.transform.GetChild (0).gameObject;
		if (slot.tag == "Gem") {
			Inventory.playerWeapon2.setGem2 (new Gem (GemElement(slot.gameObject), 
				System.Int32.Parse(slot.GetComponentInChildren<UnityEngine.UI.Text> ().text)));
		}
		else {
			Inventory.playerWeapon2.setGem2 (new Gem ());
		}
		gemSlot = GameObject.Find ("W2Slot 3");
		slot = gemSlot.transform.GetChild (0).gameObject;
		if (slot.tag == "Gem") {
			Inventory.playerWeapon2.setGem3 (new Gem (GemElement(slot.gameObject), 
				System.Int32.Parse(slot.GetComponentInChildren<UnityEngine.UI.Text> ().text)));
		}
		else {
			Inventory.playerWeapon2.setGem3 (new Gem ());
		}
		gemSlot = GameObject.Find ("ASlot 1");
		slot = gemSlot.transform.GetChild (0).gameObject;
		if (slot.tag == "Gem") {
			Inventory.playerArmor.setGem1 (new Gem (GemElement(slot.gameObject), 
				System.Int32.Parse(slot.GetComponentInChildren<UnityEngine.UI.Text> ().text)));
		}
		else {
			Inventory.playerArmor.setGem1 (new Gem ());
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

	}
	public static int FindGem(Gem gem)
	{
		for (int i = 0; i < Inventory.inventory.Count; i++) {
			if ((Inventory.inventory [i].getElement () == gem.getElement ()) && Inventory.inventory [i].getGrade() == gem.getGrade ()) {
				return i;
			}
		}
		return -1;
	}
	public static char GemElement(GameObject temp)
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
		if(temp.GetComponent<UnityEngine.UI.Image> ().color == Inventory.brown)
		{
			return 'E';
		}
		return 'N';
	}
}
