using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public int level = 0;
    public static GameManager instance = null;
	private BoardManager boardScript;

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
		if (level == 0) {
			boardScript = GetComponent<Fire>();
		}
		if (level == 1) {
			boardScript = GetComponent<Earth>();
		}
		if (level == 2) {
			boardScript = GetComponent<Water>();
		}
		if (level == 3) {
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