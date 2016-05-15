using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mazeEndHandler : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			SceneManager.LoadScene ("graveScene");
		}
	}
}
