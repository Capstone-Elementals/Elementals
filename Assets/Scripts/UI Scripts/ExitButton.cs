using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	public void Destoryer(){
		Destroy(GameObject.Find("FireMapCam"));
		Destroy(GameObject.Find("Board"));
		Destroy(GameObject.Find("Edge"));
		Destroy(GameObject.Find("Objects"));
		Destroy(GameObject.Find("Testplayer no cam"));
		Destroy(GameObject.Find("Fire_Background"));
		Destroy(GameObject.Find("Fire Map"));									
	}
}
