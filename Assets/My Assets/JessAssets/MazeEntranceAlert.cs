using UnityEngine;
using System.Collections;

public class MazeEntranceAlert : MonoBehaviour {
	AlertViewHandler alert;
	int currentMsg = 0;




	// Use this for initialization
	void Start () {
		alert = FindObjectOfType<AlertViewHandler> ();

		alert.showAlert ("You might think that you've escaped all peril... but evil lies ahead.\n" +
			"The only way out is through the graveyard... " +
			"alas... the graveyard gates are locked.");
		
		alert.showAlert ("The key is stashed away within a wooden chest that is hidden somewhere within this maze.\n" +
			"Beware...the chest is guarded");

		alert.showAlert ("Find the KEYS to the graveyard");
	}
	
	// Update is called once per frame
	void Update () {


				
	}
}
