using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDamage : MonoBehaviour, ElementalDamage {
	public float damage = 0f;

	public WaterDamage (float c_damage) {
		damage = c_damage;
	}

	public void apply_damage (GameObject apply_to) {
		apply_to.gameObject.GetComponent<Health> ().Damage (damage, 'W');
	}
}
