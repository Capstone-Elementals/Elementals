using System.Collections;
using System.Collections.Generic;

using UnityEngine;

//Require a sprite renderer as that will be the method of changing the color.
[RequireComponent(typeof(SpriteRenderer))]
//Require a transform even though it should already be there. Just to be safe!
[RequireComponent(typeof(Transform))]
public class HealthBar : MonoBehaviour {

	private SpriteRenderer renderer;
	private Health parentHealth;

	void Start() {
		//Grab the sprite renderer for color control
		renderer = (SpriteRenderer)GetComponent<SpriteRenderer> ();

		if (renderer != null)
			Debug.Log ("Successfully found sprite renderer.");

		//Grab the health component of the parent object for health data
		parentHealth = (Health) this.transform.parent.GetComponent<Health>();

		if (parentHealth != null)
			Debug.Log ("Successfully found parent health.");

		update (1, 1);
	}


	//Updates the healthbar of a gameObject. Called from a Health script. 
	public void update(int health, int maxHealth) {
		/*
		//Catch and log any instances of trying to update a healthbar object that doesn't have health
		if (parentHealth == null) {
			Debug.LogError ("Tried to update a healthbar w/ no health object", this);
			return;
		}

		//Determine the red and green component of the health bar using the ratio of health to maxHealth
		float greenComponent = (float)parentHealth.health / (float)parentHealth.maxHealth;
		float redComponent = 1f - greenComponent;
		//Colors are given in a vector4 as Red, Green, Blue, Opacity
		renderer.color = new Vector4(redComponent, greenComponent, 0, 1);
		*/

		//Determine the red and green component of the health bar using the ratio of health to maxHealth
		float greenComponent = (float)health / (float)maxHealth;
		float redComponent = 1f - greenComponent;
		//Colors are given in a vector4 as Red, Green, Blue, Opacity
		renderer.color = new Vector4(redComponent, greenComponent, 0, 1);
	}


}
