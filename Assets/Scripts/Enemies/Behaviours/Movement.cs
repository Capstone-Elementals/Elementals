using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

	public enum movementDirection {left, right}

	public movementDirection direction = movementDirection.right;
	public float speed = .5f;

	private Rigidbody2D	rb2d;

	// Use this for initialization
	void Start () {
		rb2d = (Rigidbody2D) GetComponent<Rigidbody2D> ();
		updateDirection ();
	}

	void updateDirection() {
		if (direction == movementDirection.left) {
			rb2d.AddForce (new Vector2(-speed, 0));
		} else {
			rb2d.AddForce (new Vector2 (speed, 0));
		}
	}
	
	public void setDirection(movementDirection newDirection) {
		if (direction != newDirection) {
			direction = newDirection;
			rb2d.velocity = Vector2.zero;
			rb2d.angularVelocity = 0f;
			updateDirection ();
		}
	}
}
