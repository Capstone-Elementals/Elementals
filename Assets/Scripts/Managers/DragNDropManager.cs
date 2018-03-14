using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDropManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject draggedItem;
	Vector3 inventorySlot;
	Transform changeSlot;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		draggedItem = gameObject;
		inventorySlot = transform.position;
		changeSlot = transform.parent;
		GetComponent<CanvasGroup> ().blocksRaycasts = false;

	}

	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}
	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		draggedItem = null;

		GetComponent<CanvasGroup> ().blocksRaycasts = true;
		if (transform.parent != changeSlot) {
			transform.position = inventorySlot;
		}
	}

	#endregion
}
