using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : PhysicsObject{

	Vector2 bulletVelocity = Vector2.zero;
	public float bulletSpeed = 10f;

	// Use this for initialization
	void Start() {
		bulletVelocity.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalShoot");
		bulletVelocity.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");
	}
	
	protected override void ComputeVelocity() {
		velocity = bulletVelocity * bulletSpeed;
		Debug.Log (velocity.x);
	}
}
