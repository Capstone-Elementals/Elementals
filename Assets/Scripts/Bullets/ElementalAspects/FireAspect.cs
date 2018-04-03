using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAspect : MonoBehaviour, Aspect {
	public int damagePerTick = 1;
	public int timePerTick = 50;
	public int ticks = 4;

	public void apply_aspect (GameObject apply_to) {
		apply_to.gameObject.AddComponent<Burn> ();
		apply_to.gameObject.GetComponent<Burn> ().setData (damagePerTick, timePerTick, ticks);
	}
}
