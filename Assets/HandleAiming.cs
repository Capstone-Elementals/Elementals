using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAiming : MonoBehaviour {

	private float currentRotation;

	// Use this for initialization
	void Start () {
		currentRotation = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 aimDirection = Vector3.zero;
		Vector3 unitVector = Vector3.zero;

		float deltaRotation = 0;

		//Need unit vectors in case joystick is not close to edge
		aimDirection.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalShoot");
		aimDirection.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");

		//Calculate position
		unitVector = aimDirection / aimDirection.magnitude;

		//Calculate angle only if a direction needs to be calculated
		if (aimDirection.x != 0 && aimDirection.y != 0) {
			float requiredAngle = Mathf.Atan2 (aimDirection.y, aimDirection.x);
			deltaRotation = requiredAngle - currentRotation;
		}

		//Apply the new position
		transform.localPosition = unitVector;
		transform.Rotate (0, 0, deltaRotation);
	}
}
