﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour 
{
	public int maxHealth = 3;
	public int damageMult = 1;
	public int health;

	private HealthBar healthBar = null;

	void Start() 
	{
		//Try to grab the healthbar of the parent. Will return null if none is found
		//  This allows for objects to have health without a health bar.
		healthBar = (HealthBar)transform.GetComponentInChildren<HealthBar>();
	}
	public void SetHealth(int inputHP)
	{
		health = inputHP;
	}
	public int GetHealth()
	{
		return health;
	}
	public void Damage(int rawDamage)
	{

		int damageTaken = rawDamage * damageMult;

		//Catch negative damage
		if (damageTaken <= 0)
			return;

		//Compensate for overkill
		if (damageTaken > health)
		{
			health = 0;
		} else 
		{
			health -= damageTaken;
		}

		UpdateBar ();
	}

	public void Heal(int healthRestored)
	{
		//Check for negative healing
		if (healthRestored <= 0)
			return;

		//Clamp health to prevent overheal
		if (health + healthRestored > maxHealth)
		{
			healthRestored = healthRestored - health;
		}

		UpdateBar ();
	}

	private void UpdateBar()
	{
		//Check if item is using a HealthBar
		if (healthBar == null)
		{
			Debug.LogError ("Health could not find healthBar child");
			return;
		}

		//Inform the healthbar of the update
		healthBar.update(health, maxHealth);
	} 
}
