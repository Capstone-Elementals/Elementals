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
[System.Serializable]
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

	}
	public void newGame()
	{
		inventory = new List<Gem> ();
		essence = 0;
		playerWeapon1 = new Weapon ();
		playerWeapon2 = new Weapon ();
		playerArmor = new Armor ();
		playerBoot = new Boot ();
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
		Debug.Log ("Saving");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/inventory.data");
		PlayerData data = new PlayerData ();
		data.essence =  Inventory.essence;
		data.inventory =  Inventory.inventory;
		data.playerWeapon1 = Inventory.playerWeapon1;
		data.playerWeapon2 =Inventory.playerWeapon2;
		data.playerArmor =Inventory.playerArmor;
		data.playerBoot =Inventory.playerBoot;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load()
	{
		if (savefile ()) {
			Debug.Log ("Load");
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/inventory.data", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			Inventory.essence = data.essence;
			Inventory.inventory = data.inventory;
			Inventory.playerWeapon1 = data.playerWeapon1;
			Inventory.playerWeapon2 = data.playerWeapon2;
			Inventory.playerArmor = data.playerArmor;
			Inventory.playerBoot = data.playerBoot;
			Debug.Log ("Inventory: " + Inventory.essence + " Data: " + data.essence);
		}
	}

	bool savefile()
	{
		if (File.Exists(Application.persistentDataPath + "/inventory.data"))
		{
			Debug.Log ("True");
			return true;
		} else 
		{
			Debug.Log ("False");
			return false;
		}
	}
	[System.Serializable]
	class PlayerData
	{
		public int essence;
	 	public List<Gem> inventory;
	 	public Weapon playerWeapon1;
		public Weapon playerWeapon2;
		public Armor playerArmor;
		public Boot playerBoot;
	}
}
