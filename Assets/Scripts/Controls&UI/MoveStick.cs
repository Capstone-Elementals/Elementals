using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class MoveStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		public int MovementRange = 100;
		public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input

		Vector3 m_StartPos;
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input

		void OnEnable()
		{
			CreateVirtualAxes();
		}

		void Start()
		{
			m_StartPos = transform.position;
		}

		void UpdateVirtualAxes(Vector3 value)
		{
			var delta = m_StartPos - value;
			delta /= MovementRange;
			m_HorizontalVirtualAxis.Update(-delta.x);
		}

		void CreateVirtualAxes()
		{
			if (!CrossPlatformInputManager.AxisExists (horizontalAxisName)) {
				m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis (horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis (m_HorizontalVirtualAxis);
			}
		}


		/**
		 * This function is a modified version of the prefab found in the Unity Cross Platform Controls package
		 */

		public void OnDrag(PointerEventData data)
		{
			Vector3 newPos = Vector3.zero;
			Vector3 unitVector = Vector3.zero;

			//Calculate change in position as a vector and calculate it's magnitude
			int deltaX = (int)(data.position.x - m_StartPos.x);

			float magnitude = (float)Math.Sqrt (Math.Pow ((double)deltaX, 2.0));

			//Divide the position vector components by the magnitude to obtain the unit vector (A vector with a magnitude of 1, but the same direction)
			unitVector.x = deltaX / magnitude;
			unitVector.z = 0;

			//Generate the absolute value of the range for both the X and Y axes
			int xRange = (int)Math.Abs ((float)MovementRange * unitVector.x);
			int yRange = (int)Math.Abs ((float)MovementRange * unitVector.y);

			//Use absolute values to ensure Mathf.Clamp recieves (var, min, max), if min and max are switched, function does not work
			deltaX = (int)Mathf.Clamp (deltaX, -xRange, xRange);

			//Assign the new position to the sticks
			newPos.x = deltaX;
			newPos.y = 0;



			transform.position = new Vector3 (m_StartPos.x + newPos.x, transform.position.y, m_StartPos.z + newPos.z);

			//Debug.Log ("Transform.position = " + transform.position);

			//Update Virtual Axes
			UpdateVirtualAxes (transform.position);

			//Debug.Log("HorizontalMoveAxis = " + Input.GetAxis("HorizontalMove"));
		}


		public void OnPointerUp(PointerEventData data)
		{
			transform.position = m_StartPos;
			UpdateVirtualAxes(m_StartPos);
		}


		public void OnPointerDown(PointerEventData data) 
		{ 
		}

		void OnDisable()
		{
		}
	}
}