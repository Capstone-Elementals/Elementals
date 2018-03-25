using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Player : PhysicsObject, PlayerInterface
{
  private float essence = 0;
	private Armor playerArmor;
	private Boot playerBoot;
	private Weapon playerWeapon1;
	private Weapon playerWeapon2;
	//Player Speed
    public float maxSpeed = 7;
	//Player Vertical speed
    public float jumpTakeOffSpeed = 7;
	//Player animator
	private Animator animator;
	//Player Sprite
    private SpriteRenderer spriteRenderer;

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
	public Vector2 getVelocity(){
		return velocity;
	}
	
	public void jump() {
		jumpPending = true;
	}

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
		//Grab X and reduce
		move.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalMove") * 0.5f;
		//Below line is deprecated
		//move.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalMove");
	
		//Horizontal movement	
		if (move.x > 0.015f || move.x < -0.015f) {
			animator.SetTrigger ("Move");
		}
		//Vertical Movement
		if (jumpPending && grounded) {
			velocity.y = jumpTakeOffSpeed;
			animator.SetTrigger ("Jump");
		} 

		jumpPending = false;

		if (move.y > -0.5 && move.x == 0) {
			animator.SetBool ("Crouch", false);
		}
		//Flipsprite when direction changes
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
       if (flipSprite)
        {
			spriteRenderer.flipX = !spriteRenderer.flipX;
        }

       // animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

	public void incrementEssence() {
		essence++;
	}
}