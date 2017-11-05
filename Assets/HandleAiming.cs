using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAiming : MonoBehaviour {

	private float currentRotation = 90;

	// Use this for initialization
	void Start () {
		transform.localPosition = new Vector3 (0, 1, 0);
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
		// I used a small deadzone to prevent weird behaviour due to very small floats.
		if (Mathf.Abs(unitVector.x) >= 0.05 && Mathf.Abs(unitVector.y) >= 0.05) {
			
			float requiredAngle = Mathf.Atan2 (aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
			deltaRotation = requiredAngle - currentRotation;
			currentRotation = requiredAngle;
		}

		//Apply the new position
		transform.localPosition = unitVector;
		transform.Rotate (0, 0, deltaRotation);
	}

}
