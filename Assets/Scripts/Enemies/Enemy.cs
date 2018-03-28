﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour 
{
	public GameObject toDrop;

	private Health health;
	private Rigidbody2D rb2d;
	public int bodyDamage = 1;

	void Start() 
	{
		// Grab the health script of an enemy
		health = (Health) GetComponent<Health> ();
		health.SetHealth(health.maxHealth);
		rb2d = (Rigidbody2D) GetComponent<Rigidbody2D> ();
		//rb2d.freezeRotation = true;
	}
	void OnTriggerEnter2D (Collider2D col) 
	{
		if (col.gameObject.name.Contains ("Bullet")) 
		{
			//Grab the damage of the incoming bullet
			int damage = col.gameObject.GetComponent<Bullet> ().damage;

			//Hurt this object
			health.Damage (damage);
		}
	}
	//Used to see if the object should die
	void FixedUpdate() 
	{
		if (health.health == 0)
			destroy ();
	}

	//This is a Unity defined function called when an object is destroyed
	void destroy() 
	{
		Instantiate<GameObject> (toDrop, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}

}