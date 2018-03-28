using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDown : MonoBehaviour {

	BoxCollider2D boxCollider;
	void Awake()
	{
		boxCollider = gameObject.GetComponent<BoxCollider2D> (); 
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		float direction = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");
		if(other.gameObject.tag == "Player"&& direction < 0)
		{
			boxCollider.enabled = false;
			Invoke ("ScriptThatTurnsPlatformBackOn", 0.5f);
		}

	}

	void ScriptThatTurnsPlatformBackOn()
	{
		boxCollider.enabled = true;
	}
}
