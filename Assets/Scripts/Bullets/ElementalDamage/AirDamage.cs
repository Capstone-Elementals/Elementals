using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDamage : MonoBehaviour {
	public float damage = 0f;

	public AirDamage (float c_damage) {
		damage = c_damage;
	}

	void OnCollisionEnter2D (Collision2D col) {
		col.gameObject.GetComponent<Health> ().Damage (damage, 'A');
	}
}
