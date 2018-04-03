using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicInitial : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		GameObject.DontDestroyOnLoad (gameObject);
	}
}
