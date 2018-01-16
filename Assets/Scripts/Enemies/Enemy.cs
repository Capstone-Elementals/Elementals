using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {

	public GameObject toDrop;

	private Health health;
	private Rigidbody2D rb2d;

	void Start() {
		// Grab the health script of an enemy
		health = (Health) GetComponent<Health> ();
		rb2d = (Rigidbody2D) GetComponent<Rigidbody2D> ();
		rb2d.freezeRotation = true;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name.Contains ("Bullet")) {
			//Grab the damage of the incoming bullet
			int damage = col.gameObject.GetComponent<Bullet> ().damage;

			//Hurt this object
			health.damage (damage);
		}
	}

	/*
	void FixedUpdate (){
		rb2d.velocity = new Vector2 (.5f, 0);
	}
	*/

	//This is a Unity defined function called when an object is destroyed
	void OnDestroy() {
		Instantiate<GameObject> (toDrop, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}

}
