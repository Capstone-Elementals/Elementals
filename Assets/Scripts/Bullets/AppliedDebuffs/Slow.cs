using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour {
	private float slowPercentage = 0.75f;
	private int duration = 50;

	private int counter = 0;

	private Movement entityMovement;

	// Use this for initialization
	void Start () {
		entityMovement = GetComponent<Movement> ();
		entityMovement.speed *= slowPercentage;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;

		if (counter > duration) {
			entityMovement.speed *= 1f / slowPercentage;
			Destroy (this);
		}
	}

	public void setData(float sa, int dur) {
		slowPercentage = sa;
		duration = dur;
	}
}
