using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAspect : MonoBehaviour {

	public int mass = 50;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().mass = mass;
	}
}
