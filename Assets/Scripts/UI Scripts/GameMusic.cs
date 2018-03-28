using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad (gameObject);
		UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
	{
		if (scene.name == "World") {
			Destroy (gameObject);
		}
	
	}
}
