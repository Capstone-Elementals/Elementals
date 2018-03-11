/*	Author: Powered by Coffee
 * 	Description: Player physics and controls are here.
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour, PlayerInterface
{	
	private Health health; //Player health
	private Stats playerStats = new Stats(); //Players Stats
	public float maxSpeed = 10f; // Player max speed
	public bool facingRight = true; //Check which way player is facing
	private Rigidbody2D rb2d; // Rigidbody 2D that is on this object
	private Animator anim; // Animator that is on this object
	private bool grounded = false; // Check if player is on the ground
	public Transform groundCheck; // transform of where to check for ground
	private float groundRadius = 0.02f; // Circle below player that checks of ground
	public LayerMask whatIsGround; // Indicates which layers of game are ground
	public float jumpForce = 700; // Force of player jump
	private Armor playerArmor = new Armor(); // Players Armor
	private Boot playerBoot = new Boot(); // Players Boots
	private Weapon playerWeapon1 = new Weapon(); // Players Weapon 1
	private Weapon playerWeapon2 = new Weapon(); // Players Weapon 2
	private bool jumpPending; // Player is jumping or not
	public Weapon equippedWeapon;
	private CapsuleCollider2D playerCollider;
	private Collision2D lastCollision = null;
	//Set and Get functions
	public void SetArmor(Armor armor)
	{
		this.playerArmor = armor;
	}
	public void SetBoot(Boot boot)
	{
		this.playerBoot = boot;
	}
	public void SetWeapon1(Weapon weapon1)
	{
		this.playerWeapon1 = weapon1;
	}
	public void SetWeapon2(Weapon weapon2)
	{
		this.playerWeapon2 = weapon2;
	}
	public void SetStat(Stats inputStats)
	{
		playerStats = inputStats;
	}
	public Armor GetArmor()
	{
		return playerArmor;
	}
	public Boot GetBoot()
	{
		return playerBoot;
	}
	public Stats GetStat()
	{
		return playerStats;
	}
	public Weapon GetWeapon1()
	{
		return playerWeapon1;
	}
	public Weapon GetWeapon2()
	{
		return playerWeapon2;
	}
	public void jump()
	{
		jumpPending = true;
	}
	public void ChangeWeapon()
	{
		if (equippedWeapon == playerWeapon1) 
		{
			equippedWeapon = playerWeapon2;
		} else 
		{
			equippedWeapon = playerWeapon1;
		}
	}
	void Awake()
	{	
		playerCollider = gameObject.GetComponent<CapsuleCollider2D> ();
		equippedWeapon = playerWeapon1;
		health = (Health) GetComponent<Health> ();
		health.SetHealth ((int)(health.maxHealth * playerStats.getVitality ()));
	}
	//Initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	//Player physics
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat("Speed", rb2d.velocity.y);
		float move = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalMove") * 0.5f;
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rb2d.velocity = new Vector2 (Mathf.Clamp(move * maxSpeed, -10, 10), rb2d.velocity.y); 
		if (move > 0 && !facingRight) 
		{
			Flip ();		
		}
		else if(move < 0 && facingRight)
		{
			Flip();
		}


	}
	void Update()
	{
		UpdateHealth ();
		//Vertical Movement
		if ((jumpPending | Input.GetKeyDown(KeyCode.Space)) && grounded) 
		{
			rb2d.AddForce (new Vector2 (0, jumpForce));
			anim.SetTrigger ("Jump");
		} 

		jumpPending = false;
		if (IsDead ())
		{
			Dead();
		}
		float direction = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalShoot");
		if (lastCollision != null) {
			if (direction < 0 && lastCollision.gameObject.layer == 9) {
				playerCollider.enabled = false;
				Invoke ("ScriptThatTurnsPlatformBackOn", 0.3f);
			}
		}

	}

	void ScriptThatTurnsPlatformBackOn()
	{
		playerCollider.enabled = true;
	}
	//Flip sprite when changing direction
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	//Damage functions
	void OnCollisionEnter2D (Collision2D col) 
	{
		lastCollision = col;
		if (col.gameObject.tag.Contains("Enemy")) 
		{
			//Grab the damage of the incoming bullet
			int damageTaken = col.gameObject.GetComponent<Enemy> ().bodyDamage;

			//Hurt this object
			health.Damage (damageTaken);
		}
	}

	//Death handlers
	bool IsDead()
	{
		if (health.health == 0) 
		{
			return true;
		} else {
			return false;
		}
	}
	void Destroy() 
	{
		Destroy (this.gameObject);
	}
	void Dead()
	{

	}
	void UpdateHealth()
	{
		GameObject.FindGameObjectWithTag ("HPbar").GetComponent<UnityEngine.UI.Text> ().text = health.GetHealth ().ToString ();
	}
}
