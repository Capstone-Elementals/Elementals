using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float maxpeed = 10f;
	bool facingRight = true;
	private Rigidbody2D rb2d;
	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700;
	private float essence = 0;
	private Armor playerArmor;
	private Boot playerBoot;
	private Weapon playerWeapon1;
	private Weapon playerWeapon2;
	private bool jumpPending;
	public void setArmor(Armor armor){
		this.playerArmor = armor;
	}
	public void setBoot(Boot boot){
		this.playerBoot = boot;
	}
	public void setWeapon1(Weapon weapon1){
		this.playerWeapon1 = weapon1;
	}
	public void setWeapon2(Weapon weapon2){
		this.playerWeapon2 = weapon2;
	}
	public Armor getArmor(){
		return playerArmor;
	}
	public Boot getBoot(){
		return playerBoot;
	}
	public Weapon getWeapon1(){
		return playerWeapon1;
	}
	public Weapon getWeapon2(){
		return playerWeapon2;
	}
	public void jump() {
		jumpPending = true;
	}
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		anim.SetFloat("vSpeed", rb2d.velocity.y);
		float move = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalMove") * 0.5f;
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rb2d.velocity = new Vector2 (move * maxpeed, rb2d.velocity.y); 
		if (move > 0 && !facingRight) {
			Flip ();		}
		else if(move < 0 && facingRight)
		{
			Flip();
		}


	}
	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool ("Ground", false);
			rb2d.AddForce (new Vector2 (0, jumpForce));
		}
	}
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}