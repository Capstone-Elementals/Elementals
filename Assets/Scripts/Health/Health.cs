using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour 
{
	public float maxHealth = 3f;
	public float damageMult = 1f;
	public float health;

	private float carry_over = 0f;
	private HealthBar healthBar = null;

	void Start() 
	{
		//Try to grab the healthbar of the parent. Will return null if none is found
		//  This allows for objects to have health without a health bar.
		healthBar = (HealthBar)transform.GetComponentInChildren<HealthBar>();
	}

	public void SetHealth(float inputHP)
	{
		health = inputHP;
	}

	public float GetHealth()
	{
		return health;
	}

	public void Damage(float rawDamage)
	{
		float damageTaken = rawDamage * damageMult;

		//Catch negative damage
		if (damageTaken <= 0f)
			return;

		carry_over += damageTaken % 1f;
		damageTaken = (float)((int)damageTaken);

		if (carry_over >= 1f) {
			carry_over--;
			damageTaken++;
		}

		//Compensate for overkill
		if (damageTaken > health)
		{
			health = 0f;
		} else {
			health -= damageTaken;
		}

		UpdateBar ();
	}

	public void Damage(float rawDamage, char element) {
		float multiplier = 1f;

		if (element == 'F') {
			if (GetComponent<AirType> () != null)
				multiplier *= 2f;

			if (GetComponent<FireType> () != null)
				multiplier /= 2f;

			Damage (rawDamage * multiplier);
		} else if (element == 'W') {
			if (GetComponent<FireType> () != null)
				multiplier *= 2f;

			if (GetComponent<WaterType> () != null)
				multiplier /= 2f;

			Damage (rawDamage * multiplier);
		} else if (element == 'E') {
			if (GetComponent<WaterType> () != null)
				multiplier *= 2f;

			if (GetComponent<EarthType> () != null)
				multiplier /= 2f;

			Damage (rawDamage * multiplier);
		} else if (element == 'A') {
			if (GetComponent<EarthType> () != null)
				multiplier *= 2f;

			if (GetComponent<AirType> () != null)
				multiplier /= 2f;

			Damage (rawDamage * multiplier);
		} else {
			Damage (rawDamage);
		}
	}

	public void Heal(float healthRestored)
	{
		//Check for negative healing
		if (healthRestored <= 0f)
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
