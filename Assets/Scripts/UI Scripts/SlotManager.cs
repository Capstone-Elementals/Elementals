using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler {

	public GameObject gem {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if (!gem) {
			DragNDropManager.draggedItem.transform.SetParent (transform);

		}
	}
	#endregion

}