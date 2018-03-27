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
	void OnTriggerEnter2D(Collider2D col)
	{
		base.OnTriggerEnter2D (col);
	}

}
