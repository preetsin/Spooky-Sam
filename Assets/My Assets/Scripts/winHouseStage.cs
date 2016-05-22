using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class winHouseStage : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene ("mazeScene");
		
		}
	
	}
}
