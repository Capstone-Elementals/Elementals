using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAspect : MonoBehaviour, Aspect {

	public int mass = 500;

	public void OnCollisionEnter2D (Collision2D col) {
		GetComponent<Rigidbody2D> ().mass = mass;
	}

	public void scale (int level) {
		mass *= level;
	}
}
