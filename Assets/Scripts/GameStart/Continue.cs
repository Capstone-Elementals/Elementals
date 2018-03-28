using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour {

	public GameObject inventory;
	// Use this for initialization
	void Awake()
	{
		if (Inventory.instance == null)
		{
			Instantiate(inventory);
		}
	}
}
