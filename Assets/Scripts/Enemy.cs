using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject toDrop;

	void OnCollisionEnter2D (Collision2D col) {

		if (col.gameObject.name.Contains ("Bullet")) {
			Instantiate<GameObject> (toDrop, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}

}
