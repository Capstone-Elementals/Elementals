using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour {

	private DNDslot trash_slot;

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

	public void trash_item () {
		GameObject trash_slot = GameObject.Find ("TrashSlot").transform.GetChild (0).gameObject;

		Inventory.inventory.RemoveAt (UIArmory.FindGem (new Gem (GemElement (trash_slot), gem_grade (trash_slot))));
		Destroy (trash_slot);
	}

}
