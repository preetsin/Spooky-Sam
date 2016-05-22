using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mazeEndHandler : MonoBehaviour {
	AlertViewHandler alerts;
	bool isWaiting = true;


	void Start(){
		alerts = FindObjectOfType<AlertViewHandler> ();
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			StartCoroutine (nextStage ());
		}
	}

	IEnumerator nextStage() {
		while (isWaiting) {

			alerts.showAlert ("Level 2 Complete");
			yield return new WaitForSeconds (0.5f);
			alerts.dismissAlert ();
			SceneManager.LoadScene ("graveScene");
			isWaiting = false;
		}

	}
}
