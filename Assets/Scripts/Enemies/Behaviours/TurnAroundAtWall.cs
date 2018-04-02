using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TurnAroundAtWall : MonoBehaviour 
{

	private Movement movement;
	private Rigidbody2D rb2d;
	private BoxCollider2D box2d;

	void Start()
	{
		movement = (Movement)GetComponent<Movement> ();
		rb2d = (Rigidbody2D)GetComponent<Rigidbody2D> ();
		box2d = (BoxCollider2D)GetComponent<BoxCollider2D> ();
	}

	//Coding plan: raycast a few pixels in the direction of movement
	// if anything but a bullet or player is hit, turn around
	void FixedUpdate ()
	{

		bool aimLeft = false;
		RaycastHit2D rh2d;
		Vector2 direction = Vector2.right;

		//Calculate the horizontal offset the raycast should use
		float offset = (box2d.size.x / 2f) * 1.03f;

		//If moving left, offset must be 
		if (movement.direction == Movement.movementDirection.left)
		{
			aimLeft = true;
			offset = -offset;
			direction = Vector2.left;
		}

		Vector2 origin = new Vector2 (rb2d.transform.position.x + offset, rb2d.transform.position.y);

		//Raycast out 5 pixels
		rh2d = Physics2D.Raycast (origin, direction, 0.03f);
		//Uncomment the following line to view raycasts
		//Debug.DrawLine ((Vector3)origin, (Vector3)(origin + direction * 0.03f));

		//Returns false if nothing was hit
		if (rh2d) 
		{
			//If hit object is another enemy or a wall turn around
			if (rh2d.rigidbody == null || rh2d.rigidbody.gameObject.name.Contains ("Enemy"))
			{
				movement.turnAround ();
			}
		}
	}
}
