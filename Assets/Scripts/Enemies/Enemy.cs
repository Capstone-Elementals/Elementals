using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour 
{
	public GameObject toDrop;
	public bool grounded;

	private Health health;
	private Rigidbody2D rb2d;
	private float initial_friction = 0;
	public int bodyDamage = 1;

	void Start() 
	{
		// Grab the health script of an enemy
		health = (Health) GetComponent<Health> ();
		setEnemyHealth ();
		rb2d = (Rigidbody2D) GetComponent<Rigidbody2D> ();
		initial_friction = GetComponent<BoxCollider2D> ().sharedMaterial.friction;
		//rb2d.freezeRotation = true;
	}

	void setEnemyHealth()
	{
		if(DifficultyManager.difficulty == 0)
		{
			health.maxHealth = 5;
			health.SetHealth (5);
		}
		if (DifficultyManager.difficulty  == 1)
		{
			health.maxHealth = 20;
			health.SetHealth (20);
		}
		if (DifficultyManager.difficulty  == 2)
		{
			health.maxHealth = 100;
			health.SetHealth (100);
		}
	}
	void FixedUpdate() {
		if (health.health == 0)
			destroy ();

		Vector2 direction = Vector2.down;
		RaycastHit2D rh2d;

		//Calculate the horizontal offset the raycast should use
		//Assumes enemies are using box (square) colliders
		float yOffset = -(GetComponent<BoxCollider2D>().size.y / 2f) * 1.03f;

		Vector2 origin = new Vector2 (rb2d.transform.position.x, rb2d.transform.position.y + yOffset);

		//Raycast out 1 pixel1
		rh2d = Physics2D.Raycast (origin, direction, 0.01f);

		if (rh2d) { //If something is hit
			grounded = true;
		} else {
			grounded = false;
		}
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

	//This is a Unity defined function called when an object is destroyed
	void destroy() 
	{
		Instantiate<GameObject> (toDrop, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}

}