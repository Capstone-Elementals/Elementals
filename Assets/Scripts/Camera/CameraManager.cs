using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {

    public float smoothTime;
    public float zoomspeed;

    private float orthographicsize_base;

	public GameObject focusObject;

    [Header("Target Elements")]
    private Vector3 followtarget;
    [SerializeField] private Vector3 focusPosition;

    // Area boundary elements
    [Header("Area Elements")]
    [SerializeField] private int currentArea = 0;
    [SerializeField] private List<GameObject> listAreaNodes = new List<GameObject>();

    void Start() {
        orthographicsize_base = Camera.main.orthographicSize;

//        if (focusObject != null)
//            FocusObject = focusObject;

        if (listAreaNodes.Count == 0)
            Debug.LogWarning(gameObject.name.ToString() + " (CameraManager): No Area boundaries are assigned. The camera will move freely to the set targets");
    }

    void Update() {

		FocusObject = focusObject;
		
        // Declare Vector3 for the new position
        Vector3 newPosition;

        if (focusObject != null) {
            followtarget = focusObject.transform.position;
        }
        else {
            followtarget = focusPosition;
        }

        newPosition = followtarget;
        newPosition.z = transform.position.z;

        if (listAreaNodes.Count > 0) {
            // If the current room size is smaller than the camera, fix the camera in the center of the room only following the focusobject over the y-axis
            if (GetAreaRect(currentArea).width < (Camera.main.orthographicSize * Camera.main.aspect) * 2) {
                newPosition.x = listAreaNodes[currentArea].transform.position.x + GetAreaRect(currentArea).width / 2;
				//newPosition.x = listAreaNodes[currentArea].transform.position.x
            }
            else {
                newPosition.x = Mathf.Clamp(followtarget.x,
                    listAreaNodes[currentArea].transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect),
                    listAreaNodes[currentArea].transform.GetChild(0).position.x - (Camera.main.orthographicSize * Camera.main.aspect));
            }

            // Same for rooms with a smaller height than the camera. Fix the camera in the center of the roomheight and follow focusobject over x-axis
            if (GetAreaRect(currentArea).height < Camera.main.orthographicSize * 2) {
                newPosition.y = listAreaNodes[currentArea].transform.position.y - GetAreaRect(currentArea).height / 2;
            }
            else {
                newPosition.y = Mathf.Clamp(followtarget.y,
                listAreaNodes[currentArea].transform.GetChild(0).position.y + Camera.main.orthographicSize,
                listAreaNodes[currentArea].transform.position.y - Camera.main.orthographicSize);
            }

            // Check wether the player is outside the boundaries of the camera. If so trigger a transition, else move towards the current set target position
            if (!GetAreaRect(currentArea).Contains(followtarget)) {
                SetNewArea();
            }
        }

        // Adjust the camera's position to that of the newly determined position
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothTime);

      //  CameraControls();
    }

    // Method to check what area the player has entered and sets the CurrentArea to this new area
    private void SetNewArea() {
        int previousArea = currentArea;

        foreach (GameObject n in listAreaNodes) {
            if (GetAreaRect(listAreaNodes.IndexOf(n)).Contains(followtarget)) {
                previousArea = listAreaNodes.IndexOf(n);

                if (previousArea == currentArea) { return; }
                currentArea = previousArea;

                Debug.Log("new area: " + currentArea.ToString());
            }
        }
    }

    // Changing the focusObject sets the focusPosition to zero
    public GameObject FocusObject {
        get { return focusObject; }
        set {
			focusObject = GameObject.FindWithTag("Player");
            focusPosition = Vector3.zero;
        }
    }

    // Changing the focusPosition sets the focusObject to null
    public Vector3 FocusPosition {
        get { return focusPosition; }
        set {
            focusPosition = value;
            focusObject = null;
        }
    }

    #region Camera Zoom
    // Public methods which can be called from outside the CameraManager. Starting the coroutines for zooming in/out accordingly
    public void ZoomIn(float _newSize) {
        StopCoroutine("I_ZoomOut");
        StartCoroutine("I_ZoomIn", _newSize);
    }
    public void ZoomOut(float _newSize) {
        StopCoroutine("I_ZoomIn");
        StartCoroutine("I_ZoomOut", _newSize);
    }

    private IEnumerator I_ZoomIn(float _newSize) {
        while (Camera.main.orthographicSize > _newSize) {
            Camera.main.orthographicSize -= Mathf.Min(zoomspeed, Camera.main.orthographicSize - _newSize);
            yield return new WaitForEndOfFrame();
        }

        Camera.main.orthographicSize = _newSize;
        yield return null;
    }

    private IEnumerator I_ZoomOut(float _newSize) {
        while (Camera.main.orthographicSize < _newSize) {
            Camera.main.orthographicSize += Mathf.Min(zoomspeed, _newSize - Camera.main.orthographicSize);
            yield return new WaitForEndOfFrame();
        }

        Camera.main.orthographicSize = _newSize;
        yield return null;
    }
    #endregion

    // Returns a Rect form of the area given in the parameter aarea
    private Rect GetAreaRect(int aarea) {
        GameObject n = listAreaNodes[aarea];
        Rect rect = new Rect(n.transform.position.x, n.transform.GetChild(0).position.y,
                n.transform.GetChild(0).position.x - n.transform.position.x, Mathf.Abs(n.transform.GetChild(0).position.y - n.transform.position.y));
        return rect;
    }

    // Returns a Rect form of the camera
    public Rect GetCameraRect() {
        Rect rect = new Rect(transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect), transform.position.y - Camera.main.orthographicSize,
            (Camera.main.orthographicSize * Camera.main.aspect) * 2, -Camera.main.orthographicSize * 2);
        return rect;
    }

    private void OnDrawGizmos() {
        if (listAreaNodes.Count == 0)
            return;

        // Draw the current selected area's bounding box
        foreach (GameObject n in listAreaNodes) {
            Transform i = n.transform;
            Transform j = n.transform.GetChild(0);

            Gizmos.color = Color.red;
            if (n == listAreaNodes[currentArea])
                Gizmos.color = Color.green;

            Gizmos.DrawLine(new Vector2(i.position.x, i.position.y), new Vector2(j.position.x, i.position.y));
            Gizmos.DrawLine(new Vector2(i.position.x, j.position.y), new Vector2(j.position.x, j.position.y));
            Gizmos.DrawLine(new Vector2(i.position.x, i.position.y), new Vector2(i.position.x, j.position.y));
            Gizmos.DrawLine(new Vector2(j.position.x, i.position.y), new Vector2(j.position.x, j.position.y));
        }
    }
		
}