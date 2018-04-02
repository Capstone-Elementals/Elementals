using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
	
	char GemElement(GameObject temp) {
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

	int gem_grade(GameObject gem) {
		return System.Int32.Parse (gem.GetComponentInChildren<UnityEngine.UI.Text> ().text);
	}


	public void check_for_upgrade () {
		GameObject gem_slot_1 = GameObject.Find ("UpSlot 1").transform.GetChild(0).gameObject;
		GameObject gem_slot_2 = GameObject.Find ("UpSlot 2").transform.GetChild(0).gameObject;

		char gem_element_1 = GemElement (gem_slot_1);
		char gem_element_2 = GemElement (gem_slot_2);

		if (gem_element_1 != gem_element_2) {
			Debug.Log ("Gems are not the same element");
			return; // If the gems are not the same element, no point in continuing
			//This is where code to change the textbox would go
		}

		int gem_grade_1 = gem_grade (gem_slot_1);
		int gem_grade_2 = gem_grade (gem_slot_2);

		if (gem_grade_1 != gem_grade_2) {
			Debug.Log ("Gems are not the same level");
			return; // If gems are not the same grade, stop
		}

		Inventory.inventory.RemoveAt(UIArmory.FindGem(new Gem (gem_element_1, gem_grade_1)));
		Inventory.inventory.RemoveAt(UIArmory.FindGem(new Gem (gem_element_1, gem_grade_1)));

		Destroy (gem_slot_1);
		Destroy (gem_slot_2);

		GameObject.Find ("UpgradeInv").GetComponent<UIUpgrade> ().add_gem_to_inventory (gem_element_1, gem_grade_1 + 1);
	}


}