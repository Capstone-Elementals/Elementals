using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAiming : MonoBehaviour 
{

	private float currentRotation = 90f;
	//Frames between shots
	public GameObject toShoot;
	public float fireRate = 30f;
	public float distanceFromPlayer = 0.5f;
	private float cooldown = 0f;
	private Weapon equipped_weapon;

	// Use this for initialization
	void Start () 
	{
		transform.localPosition = new Vector3 (0, distanceFromPlayer, 0);
	}

	void Awake ()
	{
		equipped_weapon = GetComponentInParent<PlayerController> ().equippedWeapon;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 aimDirection = Vector3.zero;
		Vector3 unitVector = Vector3.zero;

		float deltaRotation = 0;

		//Need unit vectors in case joystick is not close to edge
		aimDirection.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalShoot");
		aimDirection.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");

		//Calculate position
		unitVector = aimDirection / aimDirection.magnitude;

		//Calculate angle only if a direction needs to be calculated
		// I used a small deadzone to prevent weird behaviour due to very small floats.
		if (Mathf.Abs(unitVector.x) >= 0.05 && Mathf.Abs(unitVector.y) >= 0.05 && !float.IsNaN(aimDirection.x)) 
		{
			PlayerController playerScript = this.GetComponentInParent<PlayerController>();
			//Apply the new position
			if (!playerScript.facingRight)
			{
				unitVector.x = -unitVector.x;
				aimDirection.x = -aimDirection.x;
			}
			float requiredAngle = Mathf.Atan2 (aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
			deltaRotation = requiredAngle - currentRotation;
			currentRotation = requiredAngle;
			transform.localPosition = unitVector * distanceFromPlayer;
			transform.Rotate (0, 0, deltaRotation);
		}

		//Check to see if the player is able to shoot a bullet
		if (aimDirection.magnitude > 0.1 && cooldown <= 0) 
		{
			//Player is able is able to shoot
			GameObject newBullet = Instantiate<GameObject>(toShoot, transform.position, transform.rotation);
			apply_weapon (newBullet, equipped_weapon);

			//Assumes that the created component is a bullet, possible null call
			cooldown = fireRate;
		}

		if(cooldown > 0)
			cooldown--;
	}


	void apply_effect (GameObject bullet, Gem to_apply) {
		switch (to_apply.getElement ()) {
		case 'F':
			FireAspect fire_aspect = bullet.AddComponent<FireAspect> ();
			fire_aspect.damagePerTick = to_apply.getGrade ();
			fire_aspect.ticks = 4 + to_apply.getGrade ();
			FireDamage fire_damage = bullet.AddComponent<FireDamage> ();
			fire_damage.damage = to_apply.getGrade ();
			break;
		case 'W':
			WaterAspect water_aspect = bullet.AddComponent<WaterAspect> ();
			water_aspect.slowPercentage = 0.75f * (float)to_apply.getGrade ();
			WaterDamage water_damage = bullet.AddComponent<WaterDamage> ();
			water_damage.damage = to_apply.getGrade ();
			break;
		case 'A':
			AirAspect air_aspect = bullet.AddComponent<AirAspect> ();
			air_aspect.damageMultiplier = 1 + to_apply.getGrade ();
			AirDamage air_damage = bullet.AddComponent<AirDamage> ();
			air_damage.damage = to_apply.getGrade ();
			break;
		case 'E':
			EarthAspect earth_aspect = bullet.AddComponent<EarthAspect> ();
			earth_aspect.mass = 500 * to_apply.getGrade ();
			EarthDamage earth_damage = bullet.AddComponent<EarthDamage> ();
			earth_damage.damage = to_apply.getGrade ();
			break;
		default:
			break;
		}
	}

	void apply_weapon (GameObject bullet, Weapon weapon) {
		apply_effect (bullet, equipped_weapon.getGem1 ());
		apply_effect (bullet, equipped_weapon.getGem2 ());
		apply_effect (bullet, equipped_weapon.getGem3 ());
	}
}
