using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletS : MonoBehaviour {

    public float velocityX = 5f;
    float velocityY = 0f;
    Rigidbody2D rd;

	// Use this for initialization
	void Start () {

        rd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rd.velocity = new Vector2(velocityX, velocityY);
		
	}
}
