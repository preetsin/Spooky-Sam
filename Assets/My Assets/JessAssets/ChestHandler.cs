using UnityEngine;
using System.Collections;

public class ChestHandler : MonoBehaviour {

	public GameObject lid;
	private bool lidCanOpen;

	// Use this for initialization
	void Start () {
		lidCanOpen = false;
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			lidCanOpen = true;
		}

		//		AlertViewHandler alert = FindObjectOfType<AlertViewHandler> ();
		//		alert.showAlert ("You walked into the fire... what a loser");
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion newQuat = new Quaternion (-0.6f, 0.8f, -0.1f, 0.1f);
		if (lidCanOpen) {
			if (lid.transform.rotation != newQuat) {
				lid.transform.Rotate (Time.deltaTime * 0, 0, -1);
				Debug.Log (lid.transform.rotation);
			} else {
				lidCanOpen = false;
			}
		}
	
	}
}
