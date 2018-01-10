using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour {

	public GameObject toDrop;

	private Health health;

	void Start() {
		// Grab the health script of an enemy
		health = (Health) GetComponent<Health> ();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name.Contains ("Bullet")) {
			//Grab the damage of the incoming bullet
			int damage = col.gameObject.GetComponent<Bullet> ().damage;

			//Hurt this object
			health.damage (damage);
		}
	}

	//This is a Unity defined function called when an object is destroyed
	void OnDestroy() {
		Instantiate<GameObject> (toDrop, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}

}
