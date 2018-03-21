using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

	private float currentAngle = -45f;
	private int counter = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter == 5) {
			counter = 0;
			UpdateRotation ();
		}


	}
	void UpdateRotation()
	{
		this.transform.Rotate(0,0,currentAngle);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Contains("Player"))
		{
			Application.LoadLevel ("FinishLevel");
		}
	}
}
