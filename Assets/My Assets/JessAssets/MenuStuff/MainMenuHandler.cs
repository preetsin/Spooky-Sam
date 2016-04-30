using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour {

	public void buttonWasPressed(string bttnName) {

		switch(bttnName) {

		case "playBttn":
			Debug.Log ("PLAY the GAME, ya psycho!");	
			SceneManager.LoadScene ("houseScene");
			break;
		default:
			Debug.Log ("Error: no button detected");
			break;

		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
