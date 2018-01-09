using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour {

	public int damage = 1;
	public int timeout = 500;
	public float speed = 1000f;

	Vector2 bulletVelocity = Vector2.zero;

	// Use this for initialization
	/**
	 * As of right now, bullets get the aim direction upon spawn
	 */
	public void Start () {
		bulletVelocity.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalShoot");
		bulletVelocity.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");
		Rigidbody2D rb2d = this.GetComponent<Rigidbody2D> ();
		//Add a force equal to speed times the unit vector of the aiming joystick
		rb2d.AddForce ((bulletVelocity / bulletVelocity.magnitude) * speed);
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
		if (timeout < 0)
			Destroy (this.gameObject);

		timeout--;
	}

	// Most bullets will call this upon collision
	public void OnCollisionEnter2D (Collision2D col) {
		Destroy(this.gameObject);
	}
}