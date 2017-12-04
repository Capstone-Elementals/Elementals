using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : PhysicsObject{

	Vector2 bulletVelocity = Vector2.zero;
	public float bulletSpeed = 100f;

	// Use this for initialization
	void Start() {
		bulletVelocity.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalShoot");
		bulletVelocity.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");
		rb2d.AddForce (bulletVelocity * bulletSpeed);
	}
	
	protected override void ComputeVelocity() {

		if (hitBufferList.Count > 0)
			Destroy(this.gameObject);

	}
}
