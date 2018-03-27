using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class NewGame : MonoBehaviour{

	// Use this for initialization
	public void DeleteOldSave()
	{
		if (File.Exists (Application.persistentDataPath + "/inventory.data")) {
			File.Delete (Application.persistentDataPath + "/inventory.data");
		}
	}

}
