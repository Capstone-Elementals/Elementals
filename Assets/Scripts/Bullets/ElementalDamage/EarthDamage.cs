using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDamage : MonoBehaviour, ElementalDamage {
	public float damage = 0f;

	public EarthDamage (float c_damage) {
		damage = c_damage;
	}

	public void apply_damage (GameObject apply_to) {
		apply_to.gameObject.GetComponent<Health> ().Damage (damage, 'E');
	}
}
