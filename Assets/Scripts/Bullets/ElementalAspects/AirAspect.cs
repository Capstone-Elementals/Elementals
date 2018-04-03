using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirAspect : MonoBehaviour, Aspect {
	public int damageMultiplier = 2;
	public int duration = 50;


	public void apply_aspect (GameObject apply_to) {
		apply_to.gameObject.AddComponent<DamageAmp> ();
		apply_to.gameObject.GetComponent<DamageAmp> ().setData (damageMultiplier, duration);

	}
}
