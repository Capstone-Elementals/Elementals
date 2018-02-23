using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : Bullet
{
	// Use this for initialization
	void Start() 
	{
		base.Start ();
	}

	void FixedUpdate()
	{
		base.FixedUpdate ();
	}

	void OnCollisionEnter2D (Collision2D col) 
	{
		base.OnCollisionEnter2D (col);
	}
}
