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
		
		//Determine the red and green component of the health bar using the ratio of health to maxHealth
		float healthRatio = (float)health / (float)maxHealth;
		float greenComponent = 0f;
		float redComponent = 0f;

		//Fit the color combination to progress from green, to yellow, to red.
		if (healthRatio >= 0.5f) {
			greenComponent = 1f;
			redComponent = Mathf.Abs(healthRatio / 0.5f - 2);
		} else {
			redComponent = 1f;
			greenComponent = healthRatio / 0.5f;
		}

		//Colors are given in a vector4 as Red, Green, Blue, Opacity
		renderer.color = new Vector4(redComponent, greenComponent, 0, 1);

		//Adjust the size of the healthbar as well
		transform.localScale = new Vector3(healthRatio, 1, 1);
	}


}
