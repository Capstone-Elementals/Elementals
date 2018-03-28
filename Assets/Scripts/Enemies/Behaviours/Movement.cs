using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour 
{

	public enum movementDirection {left, right}

	public movementDirection direction = movementDirection.right;
	public float speed = .25f;

	private Rigidbody2D	rb2d;

	// Use this for initialization
	void Start () 
	{
		rb2d = (Rigidbody2D) GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		Vector2 currentVelocity = rb2d.velocity;

		if (direction == movementDirection.right) 
		{
			rb2d.velocity = new Vector2 (speed, currentVelocity.y);
		} else 
		{
			rb2d.velocity = new Vector2 (-speed, currentVelocity.y);
		}
	}
	
	public void setDirection(movementDirection newDirection) 
	{
		if (direction != newDirection) 
		{
			direction = newDirection;
		}
	}

	public void turnAround() 
	{
		if (direction == movementDirection.right)
			setDirection (movementDirection.left);
		else
			setDirection (movementDirection.right);
	}
}
