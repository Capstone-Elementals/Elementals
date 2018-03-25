using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class NewGame : MonoBehaviour{

	public GameObject inventory;
	// Use this for initialization
	void Awake()
	{
		if (File.Exists (Application.persistentDataPath + "/inventory.data")) {
			File.Delete (Application.persistentDataPath + "/inventory.data");
		}
		if (Inventory.instance == null)
		{
			Instantiate(inventory);
		}
	}

}
