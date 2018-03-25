/*	Author: Powered by Coffee
 * 	Description: Inventory object. Used to control players inventory.
 *  Will communicate with ui scenes.
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class Inventory : MonoBehaviour 
{
	static public int essence;
	static public List<Gem> inventory;
	static public Weapon playerWeapon1;
	static public Weapon playerWeapon2;
	static public Armor playerArmor;
	static public Boot playerBoot;
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
		if (!savefile()) 
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
			Load();
		}
	}
	void Start () 
	{

	}

	public void AddGem(Gem gem)
	{
		inventory.Add (gem);
	}
	public void removeGem(Gem gem)
	{
		inventory.Remove (gem);
	}
	public List<Gem> getInventory()
	{
		return inventory;
	}
	public void setInventory(List<Gem> newinventory)
	{
		inventory = newinventory;
	}
	public void AddEssence(int increment)
	{
		essence += increment;
	}
	public void ReduceEssence(int decrement)
	{
		essence -= decrement;
	}
	public int getEssence()
	{
		return essence;
	}
	public void SetEssence(int newessence)
	{
		essence = newessence;
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
	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/inventory.data");

		Inventory data = new Inventory ();
		data.SetEssence (Inventory.essence);
		data.setInventory (Inventory.inventory);
		data.SetWeapon1 (Inventory.playerWeapon1);
		data.SetWeapon2 (Inventory.playerWeapon2);
		data.SetArmor (Inventory.playerArmor);
		data.SetBoot (Inventory.playerBoot);

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load()
	{
		if (savefile ()) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/inventory.data", FileMode.Open);
			Inventory data = (Inventory)bf.Deserialize (file);
			file.Close ();

			Inventory.essence = data.getEssence ();
			Inventory.inventory = data.getInventory ();
			Inventory.playerWeapon1 = data.GetWeapon1 ();
			Inventory.playerWeapon1 = data.GetWeapon2 ();
			Inventory.playerArmor = data.GetArmor ();
			Inventory.playerBoot = data.GetBoot ();
		}
	}
	bool savefile()
	{
		
		if (File.Exists(Application.persistentDataPath + "/inventory.data"))
		{
			return true;
		} else 
		{
			return false;
		}
	}
}
