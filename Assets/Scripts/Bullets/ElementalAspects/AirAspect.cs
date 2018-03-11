using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAspect : MonoBehaviour, Aspect {
	public int damageMultiplier = 1;
	public int duration = 50;

	public void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.AddComponent<DamageAmp> ();
			col.gameObject.GetComponent<DamageAmp> ().setData (damageMultiplier, duration);
		}

	}

	public void scale (int level) {
		damageMultiplier += level;
	}
}
