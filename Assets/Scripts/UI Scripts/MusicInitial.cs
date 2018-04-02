using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicInitial : MonoBehaviour {

	// Use this for initialization
	void OnEnable() {
		GameObject.DontDestroyOnLoad (gameObject);
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(	Scene scene, LoadSceneMode mode)
	{

		if (scene.name == "World") {
				
			Destroy (gameObject);
			
		}
	}
}
