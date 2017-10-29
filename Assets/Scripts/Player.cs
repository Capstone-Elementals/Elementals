using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Player : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
	private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

		move.x = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("HorizontalMove");
		move.y = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis ("VerticalMove");
	
			
		if (move.x > 0.015f || move.x < -0.015f) {
			animator.SetBool ("Move", true);
		} else {
			animator.SetBool ("Move", false);
		}
		if (move.y > 0.9 && grounded) {
			velocity.y = jumpTakeOffSpeed;
		} else if (move.y < -0.9) {
			velocity.y = -jumpTakeOffSpeed * 2f;
		}

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
       if (flipSprite)
        {
			spriteRenderer.flipX = !spriteRenderer.flipX;
        }

       // animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}