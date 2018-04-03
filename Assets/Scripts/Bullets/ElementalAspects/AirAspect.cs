using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAspect : MonoBehaviour {
	public int damageMultiplier = 2;
	public int duration = 50;


	public void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.AddComponent<DamageAmp> ();
			col.gameObject.GetComponent<DamageAmp> ().setData (damageMultiplier, duration);
		}

	}
}
