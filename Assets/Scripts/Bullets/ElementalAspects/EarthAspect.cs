using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAspect : MonoBehaviour {

	public int mass = 500;

	public void OnCollisionEnter2D (Collision2D col) {
		GetComponent<Rigidbody2D> ().mass = mass;
	}
}
