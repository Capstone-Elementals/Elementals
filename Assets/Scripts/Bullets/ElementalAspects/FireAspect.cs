using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAspect : MonoBehaviour, Aspect {
	public int damagePerTick = 1;
	public int timePerTick = 50;
	public int ticks = 4;

	public void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.AddComponent<Burn> ();
			col.gameObject.GetComponent<Burn> ().setData (damagePerTick, timePerTick, ticks);
		}
	}

	public void scale (int level) {
		damagePerTick *= level;
		ticks += level;
	}
}
