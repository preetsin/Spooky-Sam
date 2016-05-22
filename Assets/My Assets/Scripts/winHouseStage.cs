using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class winHouseStage : MonoBehaviour {
	AlertViewHandler alerts;
	bool isWaiting = true;

	void Start(){
		alerts = FindObjectOfType<AlertViewHandler> ();


	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			StartCoroutine (nextStage ());
		}
	
	
	}

	IEnumerator nextStage() {
		while (isWaiting) {

			alerts.showAlert ("Level 1 Complete");
			yield return new WaitForSeconds (0.5f);
			alerts.dismissAlert ();
			SceneManager.LoadScene ("mazeScene");
			isWaiting = false;
		}
	
	}
}
