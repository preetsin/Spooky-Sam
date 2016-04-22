using UnityEngine;
using System.Collections;

public class DoorLeverScript : MonoBehaviour {

	TextMesh leverText;
//	GameObject player;
//	InputScript playerScript;
//	GameObject graveyardLeftExitDoor;
//	Animator graveyardLeftExitDoorAnimator;

	void Start () 
	{
		leverText = GameObject.Find ("LeverText").GetComponent<TextMesh> ();
//		player = GameObject.FindGameObjectWithTag ("Player");
//		playerScript = player.GetComponent<InputScript> ();
//		graveyardLeftExitDoor = GameObject.FindGameObjectWithTag ("GraveyardLeftExitDoor");
//		graveyardLeftExitDoorAnimator = graveyardLeftExitDoor.GetComponent<Animator> ();
	}

	void OnTriggerStay()
	{
		leverText.text = "Press Some Button";

	}

	void OnTriggerEnter(Collider other)
	{
//		leverText.text = "Press Some Button";
		//Debug.Log ("Object Entered Trigger");
	}

	void OnTriggerExit(Collider other)
	{
		leverText.text = "";
		//Debug.Log ("Object Exit Trigger");
	}

	void Update()
	{
//		if (playerScript.isDoorLeverToggled) 
//		{
//			Debug.Log ("DOOR TOGGLED ON");
//			graveyardLeftExitDoorAnimator.SetBool ("GateOpen", true);
//
//		} 
//		else if (!playerScript.isDoorLeverToggled) 
//		{
//			graveyardLeftExitDoorAnimator.SetBool ("GateOpen", false);
//			Debug.Log ("DOOR TOGGLED OFF");
//
//		}
	
	}


}
