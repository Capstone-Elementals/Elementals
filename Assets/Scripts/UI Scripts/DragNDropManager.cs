using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDropManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject draggedItem;
	private Image gem;
	Vector3 inventorySlot;
	GameObject Trash;
	Vector3 TrashT;
	Transform changeSlot;

	private void Awake() {

		gem = GetComponent<Image>();
	}



	public void OnBeginDrag (PointerEventData eventData)
	{
		draggedItem = gameObject;
		inventorySlot = transform.position;
//		changeSlot = transform.parent;
//		GetComponent<CanvasGroup> ().blocksRaycasts = false;
		//gem.color = Color.green;

	}



	public void OnDrag (PointerEventData eventData)
	{
		transform.position = eventData.position;
	}





	public void OnEndDrag (PointerEventData eventData)
	{
		//gem.color = Color.white;
		//draggedItem = null;
		Trash = GameObject.FindWithTag("Trash");

		TrashT = Trash.transform.position;

		if (gameObject.transform.position == TrashT) {
			
			GameObject.Destroy (gameObject);
		} else {

			transform.position = inventorySlot;
		}
	}


}

