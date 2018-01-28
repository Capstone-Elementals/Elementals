using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
	private BoardManager boardScript;
	//Called when Game started
    void Awake()
    {


        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
		if (LevelManager.level == 0) {
			boardScript = GetComponent<Fire>();
		}
		if (LevelManager.level  == 1) {
			boardScript = GetComponent<Earth>();
		}
		if (LevelManager.level  == 2) {
			boardScript = GetComponent<Water>();
		}
		if (LevelManager.level  == 3) {
			boardScript = GetComponent<Air>();
		}
        

        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
		boardScript.SetupScene ();

    }



    //Update is called every frame.
    void Update()
    {

    }
}