/*	Author: Powered by Coffee
 * 	Description: Inventory object. Used to control players inventory.
 *  Will communicate with ui scenes.
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour 
{
	static public int essence;
	static private List<Gem> inventory;
	static private Weapon playerWeapon1;
	static private Weapon playerWeapon2;
	static private Armor playerArmor;
	static private Boot playerBoot;
	// Use this for initialization
	public static Inventory instance = null;
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
	void Start () 
	{
		if (savefile()) 
		{
			inventory = new List<Gem> ();
			essence = 0;
			playerWeapon1 = new Weapon ();
			playerWeapon2 = new Weapon ();
			playerArmor = new Armor ();
			playerBoot = new Boot ();
		} else
		{
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
	void setInventory(List<Gem> newinventory)
	{
		inventory = newinventory;
	}
	void AddEssence(int increment)
	{
		essence += increment;
	}
	void ReduceEssence(int decrement)
	{
		essence -= decrement;
	}
	//Set and Get functions
	public void SetArmor(Armor armor)
	{
		playerArmor = armor;
	}
	public void SetBoot(Boot boot)
	{
		playerBoot = boot;
	}
	public void SetWeapon1(Weapon weapon1)
	{
		playerWeapon1 = weapon1;
	}
	public void SetWeapon2(Weapon weapon2)
	{
		playerWeapon2 = weapon2;
	}
	public Armor GetArmor()
	{
		return playerArmor;
	}
	public Boot GetBoot()
	{
		return playerBoot;
	}

	public Weapon GetWeapon1()
	{
		return playerWeapon1;
	}
	public Weapon GetWeapon2()
	{
		return playerWeapon2;
	}
	// Update is called once per frame
	void Update ()
	{
		
	}
	bool savefile()
	{
		bool exists = false;
		//Check if a save file exists
		if (exists)
		{
			return true;
		} else 
		{
			return false;
		}
	}
}
