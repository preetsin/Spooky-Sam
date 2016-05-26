using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuHandler : MonoBehaviour {

	public void buttonWasPressed(string bttnName) {

		switch(bttnName) {

		case "playBttn":
			Debug.Log ("Play bttn selected");	
			SceneManager.LoadScene ("houseScene");
			break;

		case "howToPlayBttn":
			Debug.Log ("How to Play bttn selected");	
			SceneManager.LoadScene ("howToPlayScene");
			break;

		case "settingsBttn":
			Debug.Log ("Settings bttn selected");	
			SceneManager.LoadScene ("settingsScene");
			break;

		case "creditsBttn":
			Debug.Log ("credits bttn selected");	
			SceneManager.LoadScene ("creditsScene");
			break;

		case "backBttn":
			Debug.Log ("back bttn selected");	
			SceneManager.LoadScene ("MainMenu");
			break;

		case "quitBttn":
			Debug.Log ("Quit bttn selected");
			Application.Quit ();
			break;

		default:
			Debug.Log ("Error: no button detected");
			break;

		}
	}
}
