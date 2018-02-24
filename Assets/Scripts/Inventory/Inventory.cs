/*	Author: Powered by Coffee
 * 	Description: Inventory object. Used to control players inventory.
 *  Will communicate with ui scenes.
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private List<Gem> inventory;
	// Use this for initialization
	void Start () {
		if (savefile()) {
			inventory = new List<Gem> ();
		} else {
			//Read save file from memory
		}
	}

	void AddGem(Gem gem)
	{
		inventory.Add (gem);
	}
	void removeGem(Gem gem)
	{
		inventory.Remove (gem);
	}
	List<Gem> getInventory()
	{
		return inventory;
	}
	void setInventory(List<Gem> inventory)
	{
		this.inventory = inventory;
	}
	// Update is called once per frame
	void Update () {
		
	}
	bool savefile()
	{
		bool exists = false;
		//Check if a save file exists
		if (exists) {
			return true;
		} else {
			return false;
		}
	}
}
