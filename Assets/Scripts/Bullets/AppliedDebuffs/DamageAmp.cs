using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAmp : MonoBehaviour {
	private int damageMultiplier = 2;
	private int duration = 50;

	private DamageAmp[] testArray;

	private int timer = 0;

	private Health entityHealth;

	void Start () {
		testArray = GetComponents<DamageAmp> ();
		if (testArray.Length > 1) {
			foreach (DamageAmp element in testArray)
				element.timer = 0;

			Destroy (this);
		}

		entityHealth = GetComponent<Health> ();
		entityHealth.damageMult = damageMultiplier;
	}

	// Update is called once per frame
	void FixedUpdate () {
		timer++;

		if (timer > duration) {
			entityHealth.damageMult = 1;
		}
	}

	public void setData(int dM, int dur) {
		damageMultiplier = dM;
		duration = dur;
	}
}
