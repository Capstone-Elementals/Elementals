using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


	protected Rigidbody2D rb2d;

	void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Translate(x, y, 0);
	}
}