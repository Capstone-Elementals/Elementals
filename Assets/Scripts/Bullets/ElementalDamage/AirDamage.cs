using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDamage : MonoBehaviour {
	public float damage = 0f;

	void OnCollisionEnter2D (Collision2D col) {
		col.gameObject.GetComponent<Health> ().Damage (damage, 'A');
	}
}
