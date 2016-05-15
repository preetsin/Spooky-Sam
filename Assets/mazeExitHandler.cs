using UnityEngine;
using System.Collections;

public class mazeExitHandler : MonoBehaviour {
	public GameObject exitGate;
	private bool gateCanOpen;


	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			if (Prefs.hasKeys) {
				gateCanOpen = true;
			} else {
				AlertViewHandler alert = FindObjectOfType<AlertViewHandler> ();
				alert.showAlert ("Nice try... but i DID try to tell you that you needed those keys.");
			}
		}

	}

	void Start () {
		gateCanOpen = false;
	}

	void Update() {
		Quaternion newQuat = new Quaternion (0.0f, -0.1f, 0.0f, 1.0f);

		if (gateCanOpen) {
			if (exitGate.transform.rotation != newQuat) {
				exitGate.transform.Rotate (Time.deltaTime * 0, -0.7f, 0);
			}
		}
	}
}
