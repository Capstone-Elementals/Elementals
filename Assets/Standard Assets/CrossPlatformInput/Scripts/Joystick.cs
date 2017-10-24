using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
	{
		public enum AxisOption
		{
			// Options for which axes to use
			Both, // Use both
			OnlyHorizontal, // Only horizontal
			OnlyVertical // Only vertical
		}

		public int MovementRange = 100;
		public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
		public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

		Vector3 m_StartPos;
		bool m_UseX; // Toggle for using the x axis
		bool m_UseY; // Toggle for using the Y axis
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
		CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

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
			delta.y = -delta.y;
			delta /= MovementRange;

			//Debug.Log ("delta.y = " + delta.y);
			//Debug.Log ("delta.x = " + delta.x);

			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Update(-delta.x);
				Debug.Log ("delta.x =" + delta.x);
				Debug.Log("Horizontal Axis Value = " + CrossPlatformInputManager.GetAxis("HorizontalMove"));
			}

			if (m_UseY)
			{
				m_VerticalVirtualAxis.Update(delta.y);
			}
		}

		void CreateVirtualAxes()
		{
			// set axes to use
			m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
			m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

			// create new axes based on axes to use
			if (m_UseX)
			{
				m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
				CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
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
			int deltaY = (int)(data.position.y - m_StartPos.y);

			float magnitude = (float)Math.Sqrt (Math.Pow ((double)deltaX, 2.0) + Math.Pow ((double)deltaY, 2.0));

			//Divide the position vector components by the magnitude to obtain the unit vector (A vector with a magnitude of 1, but the same direction)
			unitVector.x = deltaX / magnitude;
			unitVector.y = deltaY / magnitude;
			unitVector.z = 0;

			//Generate the absolute value of the range for both the X and Y axes
			int xRange = (int)Math.Abs ((float)MovementRange * unitVector.x);
			int yRange = (int)Math.Abs ((float)MovementRange * unitVector.y);

			//Use absolute values to ensure Mathf.Clamp recieves (var, min, max), if min and max are switched, function does not work
			deltaX = (int)Mathf.Clamp (deltaX, -xRange, xRange);
			deltaY = (int)Mathf.Clamp (deltaY, -yRange, yRange);

			//Assign the new position to the sticks
			newPos.x = deltaX;
			newPos.y = deltaY;

			transform.position = new Vector3 (m_StartPos.x + newPos.x, m_StartPos.y + newPos.y, m_StartPos.z + newPos.z);

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


		public void OnPointerDown(PointerEventData data) { }

		void OnDisable()
		{
			// remove the joysticks from the cross platform input
			if (m_UseX)
			{
				m_HorizontalVirtualAxis.Remove();
			}
			if (m_UseY)
			{
				m_VerticalVirtualAxis.Remove();
			}
		}
	}
}