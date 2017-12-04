using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour{

	Vector2 bulletVelocity = Vector2.zero;
	public float bulletSpeed = 1000f;
	public string identifier = "bullet";
	public float timeout = 500f;

	// Use this for initialization
	void Start() {
		bulletVelocity.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalShoot");
		bulletVelocity.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");
		Rigidbody2D rb2d = this.GetComponent<Rigidbody2D> ();
		rb2d.AddForce (bulletVelocity * bulletSpeed);
	}

	void FixedUpdate(){
		if (timeout < 0)
			Destroy (this.gameObject);

		timeout--;
	}

	void OnCollisionEnter2D (Collision2D col) {
		Destroy(this.gameObject);
	}
}
