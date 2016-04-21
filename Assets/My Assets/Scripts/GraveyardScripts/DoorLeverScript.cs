using UnityEngine;
using System.Collections;

public class DoorLeverScript : MonoBehaviour {

	TextMesh leverText;

	void Start () {
		leverText = GameObject.Find ("LeverText").GetComponent<TextMesh> ();
	}

	void OnTriggerEnter(Collider other){
		leverText.text = "Press Some Button";
		Debug.Log ("Object Entered Trigger");
	}

	void OnTriggerExit(Collider other){
		leverText.text = "";
		Debug.Log ("Object Exit Trigger");
	}
}
