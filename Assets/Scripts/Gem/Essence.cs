using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour 
{
	void OnCollisionEnter2D (Collision2D col) 
	{
		if (col.gameObject.name.Contains ("player")) 
		{
			Destroy (this.gameObject);
			//Increment essence here
		}
	}
}
