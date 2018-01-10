using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {
	public int maxHealth = 3;
	public int health;

	private HealthBar healthBar = null;

	void Start() {
		//Try to grab the healthbar of the parent. Will return null if none is found
		//  This allows for objects to have health without a health bar.
		healthBar = (HealthBar)transform.GetComponentInChildren<HealthBar>();
		health = maxHealth;
	}

	public void damage(int damageTaken) {

		//Catch negative damage
		if (damageTaken <= 0)
			return;

		//Compensate for overkill
		if (damageTaken > health) {
			health = 0;
		} else {
			health -= damageTaken;
		}

		//If no health left, destroy the gameObject
		if (health <= 0) {
			Destroy (this.gameObject);
		}

		updateBar ();
	}

	public void heal(int healthRestored) {
		//Check for negative healing
		if (healthRestored <= 0)
			return;

		//Clamp health to prevent overheal
		if (health + healthRestored > maxHealth) {
			healthRestored = healthRestored - health;
		}

		updateBar ();
	}

	private void updateBar() {
		//Check if item is using a HealthBar
		if (healthBar == null) {
			Debug.LogError ("Health could not find healthBar child");
			return;
		}

		//Inform the healthbar of the update
		healthBar.update(health, maxHealth);
	} 
}
