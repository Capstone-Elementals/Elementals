﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUI : MonoBehaviour {
	GameObject player;
	GameObject gem1;
	GameObject gem2;
	GameObject gem3;
	GameObject essence;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		gem1 = GameObject.FindGameObjectWithTag ("Gem1");
		gem2 = GameObject.FindGameObjectWithTag ("Gem2");
		gem3 = GameObject.FindGameObjectWithTag ("Gem3");
		essence = GameObject.FindGameObjectWithTag ("Essence");
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		} else {
			gem1.GetComponentInChildren<UnityEngine.UI.Text> ().text = player.GetComponent<PlayerController> ().equippedWeapon.getGem1 ().getGrade ().ToString ();
			gem2.GetComponentInChildren<UnityEngine.UI.Text> ().text = player.GetComponent<PlayerController> ().equippedWeapon.getGem2 ().getGrade ().ToString ();
			gem3.GetComponentInChildren<UnityEngine.UI.Text> ().text = player.GetComponent<PlayerController> ().equippedWeapon.getGem3 ().getGrade ().ToString ();
			gem1.GetComponent<UnityEngine.UI.Image> ().color = getGemColor (player.GetComponent<PlayerController> ().equippedWeapon.getGem1 ());
			gem2.GetComponent<UnityEngine.UI.Image> ().color = getGemColor (player.GetComponent<PlayerController> ().equippedWeapon.getGem2 ());
			gem3.GetComponent<UnityEngine.UI.Image> ().color = getGemColor (player.GetComponent<PlayerController> ().equippedWeapon.getGem3 ());
			essence.GetComponentInChildren<UnityEngine.UI.Text> ().text = Inventory.essence.ToString ();
		}
	}
	Color getGemColor(Gem gem)
	{
		switch (gem.getElement()) {
		case 'F':
			return Color.red;
			break;
		case 'W':
			return Color.blue;
			break;
		case 'A':
			return Color.cyan;
			break;
		case 'E':
			return Inventory.brown;
			break;
		default:
			break;
		}
		return Color.white;
	}
}
