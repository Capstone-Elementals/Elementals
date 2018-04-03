using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour 
{
	void OnCollisionEnter2D (Collision2D col) 
	{
		if (col.gameObject.name.Contains ("player")) 
		{
			Destroy (this.gameObject);
			//Increment essence here

			switch(DifficultyManager.difficulty) {
			case 0:
				Inventory.essence += 1;
				Inventory.tempEssence += 1;
				break;
			case 1:
				Inventory.essence += 3;
				Inventory.tempEssence += 3;
				break;
			case 2:
				Inventory.essence += 5;
				Inventory.tempEssence += 5;
				break;
			default:
				Inventory.essence += 1;
				Inventory.tempEssence += 1;
				break;
			}

		}
	}
}
