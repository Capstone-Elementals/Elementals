using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAspect : MonoBehaviour, Aspect {

	public int mass = 500;

	public void apply_aspect (GameObject apply_to) {
		GetComponent<Rigidbody2D> ().mass = mass;
	}
}
