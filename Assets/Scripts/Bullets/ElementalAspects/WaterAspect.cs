using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAspect : MonoBehaviour, Aspect {
	public float slowPercentage = 0.75f;
	public int duration = 50;

	public void apply_aspect (GameObject apply_to) {
		apply_to.gameObject.AddComponent<Slow> ();
		apply_to.gameObject.GetComponent<Slow> ().setData (slowPercentage, duration);

	}
}
