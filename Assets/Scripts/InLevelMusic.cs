using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelMusic : MonoBehaviour {



	void Awake () {

	GameObject Music = GameObject.Find("Game Music 1");
		if(Music){

			Destroy (Music);

		}
		
	}
	

}
