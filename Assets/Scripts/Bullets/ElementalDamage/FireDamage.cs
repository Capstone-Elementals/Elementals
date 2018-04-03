using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour {
	public float damage = 0f;

	public FireDamage (float c_damage) {
		damage = c_damage;
	}

	void OnCollisionEnter2D (Collision2D col) {
		col.gameObject.GetComponent<Health> ().Damage (damage, 'F');
	}
}
