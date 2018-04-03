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
	// Update is called once per frame
	void FixedUpdate () {
		updateDamage ();
		GameObject.Find ("W1D").GetComponent<TMPro.TextMeshProUGUI> ().text = Inventory.playerWeapon1.getTotalDamage ().ToString ();
		GameObject.Find ("W2D").GetComponent<TMPro.TextMeshProUGUI> ().text = Inventory.playerWeapon2.getTotalDamage ().ToString ();
		string armorDef;
		armorDef = (Inventory.playerArmor.getBonusDefense () * 10).ToString () + "% " + Inventory.playerArmor.getGem1 ().getElementS ();
		GameObject.Find ("DEF").GetComponent<TMPro.TextMeshProUGUI> ().text = armorDef;
		switch (Inventory.playerArmor.getGem1 ().getElement()) {
		case 'F':
				GameObject.Find ("DEF").GetComponent<TMPro.TextMeshProUGUI> ().color = Color.red;
				break;
		case 'A':
			GameObject.Find ("DEF").GetComponent<TMPro.TextMeshProUGUI> ().color = Color.cyan;
				break;
			case 'E':
			GameObject.Find ("DEF").GetComponent<TMPro.TextMeshProUGUI> ().color = Inventory.brown;
				break;
			case 'W':
			GameObject.Find ("DEF").GetComponent<TMPro.TextMeshProUGUI> ().color = Color.blue;
				break;
			default:
				break;
		}
	}
	void updateDamage()
	{
		Inventory.playerWeapon1.calculateBonusDamage ();
		Inventory.playerWeapon1.calculateTotalDamage ();
		Inventory.playerWeapon2.calculateBonusDamage ();
		Inventory.playerWeapon2.calculateTotalDamage ();
		Inventory.playerArmor.calculateBonusDefense();
		Inventory.playerArmor.calculateTotalDefense();
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
