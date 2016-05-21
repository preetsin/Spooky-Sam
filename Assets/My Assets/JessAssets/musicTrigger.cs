using UnityEngine;
using System.Collections;

public class musicTrigger : MonoBehaviour {

	AudioSource musicSource;

	void OnTriggerEnter(Collider col) {

		if (Prefs.musicEnabled) {
			musicSource.Play ();
		}
	}

	void Start () {
		musicSource = gameObject.GetComponent<AudioSource> ();
	}
	
	void Update () {
	
	}
}
