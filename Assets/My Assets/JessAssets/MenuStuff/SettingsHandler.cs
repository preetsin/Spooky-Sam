using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour {

	public Toggle musicToggle;
	public Toggle sfxToggle;


	public void updateSettings() {
		if (musicToggle.isOn) {
			Prefs.musicEnabled = true;
		} else {
			Prefs.musicEnabled = false;
		}

		if (sfxToggle.isOn) {
			Prefs.sfxEnabled = true;
		} else {
			Prefs.sfxEnabled = false;
		}

		Debug.Log ("Music : " + Prefs.musicEnabled);
		Debug.Log ("SFX : " + Prefs.sfxEnabled);

	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
