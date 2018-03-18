using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	private float currentAngle = 90f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentAngle += 10;
		this.transform.Rotate(0,0,currentAngle); 
	}
}
