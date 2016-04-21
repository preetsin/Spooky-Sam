using UnityEngine;
using System.Collections;

public class musicTrigger : MonoBehaviour {

	AudioSource musicSource;

	void OnTriggerEnter(Collider col) {
		musicSource.Play ();

	}

	void Start () {
		musicSource = gameObject.GetComponent<AudioSource> ();
	}
	
	void Update () {
	
	}
}
