using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour, ElementalDamage {
	public float damage = 0f;

	public FireDamage (float c_damage) {
		damage = c_damage;
	}

	public void apply_damage (GameObject apply_to) {
		apply_to.gameObject.GetComponent<Health> ().Damage (damage, 'F');
	}
}
