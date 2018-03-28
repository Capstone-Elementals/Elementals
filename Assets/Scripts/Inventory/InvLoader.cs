/*	Author: Powered by Coffree
 * Description: Loads up game on start up
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvLoader : MonoBehaviour
{
	public Inventory inventory;
	// Use this for initialization
	void Awake()
	{
		if (Inventory.instance == null)
		{
			Instantiate(inventory);
		}
	}
}