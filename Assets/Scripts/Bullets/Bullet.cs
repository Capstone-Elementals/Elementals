using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour 
{
	public int damage = 1;
	public int timeout = 500;
	public float speed = 500f;

	Vector2 bulletVelocity = Vector2.zero;

	// Use this for initialization
	/**
	 * As of right now, bullets get the aim direction upon spawn using the start method
	 */
	public void Start () 
	{
		bulletVelocity.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalShoot");
		bulletVelocity.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");
		Rigidbody2D rb2d = this.GetComponent<Rigidbody2D> ();
		Physics2D.IgnoreLayerCollision (12, 9);
		//Add a force equal to speed times the unit vector of the aiming joystick
		rb2d.AddForce ((bulletVelocity / bulletVelocity.magnitude) * speed);
	}
	
	// Update is called once per frame
	public void FixedUpdate () 
	{
		if (timeout < 0)
			Destroy (this.gameObject);

		timeout--;
	}

	// Most bullets will call this upon Trigger
	public void OnTriggerEnter2D(Collider2D col)
	{
		if (!(col.gameObject.layer == 9)) {
			if (col.gameObject.tag == "Enemy") {
				foreach (Aspect aspect in GetComponents<Aspect>()) {
					aspect.apply_aspect (col.gameObject);
				}

				foreach (ElementalDamage e_damage  in GetComponents<ElementalDamage> ()) {
					e_damage.apply_damage (col.gameObject);
				}

			}

			Destroy (this.gameObject);
		}
	}
}