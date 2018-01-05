using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Player : PhysicsObject
{
	//Player Speed
    public float maxSpeed = 7;
	//Player Vertical speed
    public float jumpTakeOffSpeed = 7;
	//Player animator
	private Animator animator;
	//Player Sprite
    private SpriteRenderer spriteRenderer;

	private float essence = 0;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
		//X and Y movement using Touch sticks
		move.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalMove");
		move.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalMove");
	
		//Horizontal movement	
		if (move.x > 0.015f || move.x < -0.015f) {
			animator.SetTrigger ("Move");
		}
		//Vertical Movement
		if (move.y > 0.5 && grounded) {
			velocity.y = jumpTakeOffSpeed;
			animator.SetTrigger ("Jump");
		} else if (move.y < -0.5) {
			if (grounded) {
				animator.SetBool("Crouch", true);
			}
			velocity.y = -jumpTakeOffSpeed * 2f;

		}
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