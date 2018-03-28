using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class JumpButton: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		//Current method of calling the player's jump function
		public PlayerInterface player = null;

		//The number of frames in which the player has to release the joystick in order to jump
		public int jumpWindow = 10;
		private int framesSinceLastTap = 0;

		public void OnPointerUp(PointerEventData data)
		{

			//If tap was fast enough to merit jump
			if (framesSinceLastTap < jumpWindow)
				player.jump ();
		}


		public void OnPointerDown(PointerEventData data) 
		{
			if (player == null)
				player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInterface>();

			framesSinceLastTap = 0;
		}
			
		void FixedUpdate() 
		{

			//Only increment frames since last tap if less than the jump window
			//  to prevent overflow fuck-ery
			if (framesSinceLastTap < jumpWindow)
				framesSinceLastTap++;
		}
	}


}