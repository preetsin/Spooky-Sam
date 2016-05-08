using UnityEngine;
using System.Collections;

public class fireCollider : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			Prefs.playerHealth -= 5;
		}

//		AlertViewHandler alert = FindObjectOfType<AlertViewHandler> ();
//		alert.showAlert ("You walked into the fire... what a loser");
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
