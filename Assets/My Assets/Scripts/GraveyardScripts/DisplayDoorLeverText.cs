using UnityEngine;
using System.Collections;

public class DisplayDoorLeverText : MonoBehaviour {

	TextMesh leverText;

	void Start () 
	{
		leverText = GameObject.Find ("LeverText").GetComponent<TextMesh> ();
	}

	void OnTriggerStay()
	{
		leverText.text = "Press Some Button";
	}

	void OnTriggerEnter(Collider other)
	{
	}

	void OnTriggerExit(Collider other)
	{
		leverText.text = "";
	}


}
