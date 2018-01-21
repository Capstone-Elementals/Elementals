using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAroundAtEdge : MonoBehaviour {

	private Movement movement;
	private Rigidbody2D rb2d;
	private BoxCollider2D box2d;

	void Start() {
		movement = (Movement)GetComponent<Movement> ();
		rb2d = (Rigidbody2D)GetComponent<Rigidbody2D> ();
		box2d = (BoxCollider2D)GetComponent<BoxCollider2D> ();
	}

	//Coding plan: raycast a few pixels in the direction of movement
	// if anything but a bullet or player is hit, turn around
	void FixedUpdate () {

		bool aimLeft = false;
		RaycastHit2D rh2d;

		Vector2 direction = Vector2.down;

		//Calculate the horizontal offset the raycast should use
		//Assumes enemies are using box (square) colliders
		float xOffset = (box2d.size.x / 2f) * 1.03f;
		float yOffset = -(box2d.size.y / 2f) * 1.03f;

		//If moving left, offset must be 
		if (movement.direction == Movement.movementDirection.left) {
			aimLeft = true;
			xOffset = -xOffset;
		}

		Vector2 origin = new Vector2 (rb2d.transform.position.x + xOffset, rb2d.transform.position.y + yOffset);

		//Raycast out 5 pixels
		rh2d = Physics2D.Raycast (origin, direction, 0.03f);
		Debug.DrawLine ((Vector3)origin, (Vector3)(origin + direction * 0.03f));

		//Returns true if nothing is hit
		if (!rh2d) {
			//If nothing was hit, that means the enemy is by an edge
			movement.turnAround();
		}
	}
}
