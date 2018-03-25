using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour {
	private int damagePerTick = 1;
	private int timePerTick = 200;
	private int ticks = 4;

	private int timer = 0;
	private int tickCount = 0;

	private Health entityHealth;

	void Start () {
		entityHealth = GetComponent<Health> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer++;

		if (timer > timePerTick) {
			entityHealth.Damage (damagePerTick, 'F');
			tickCount++;
			timer = 0;

			if (tickCount >= ticks)
				Destroy (this);
			
		}
	}

	public void setData(int dpt, int tpt, int numTicks) {
		damagePerTick = dpt;
		timePerTick = tpt;
		ticks = numTicks;
	}
}
