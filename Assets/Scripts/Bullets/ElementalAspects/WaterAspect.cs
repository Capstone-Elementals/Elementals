using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAspect : MonoBehaviour, Aspect {
	public float slowPercentage = 0.75f;
	public int duration = 50;

	public void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.AddComponent<Slow> ();
			col.gameObject.GetComponent<Slow> ().setData (slowPercentage, duration);
		}

	}

	public void scale (int level) {
		slowPercentage *= level;
		//duration *= level;
	}
}
