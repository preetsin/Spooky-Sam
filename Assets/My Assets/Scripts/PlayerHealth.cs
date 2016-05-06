using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public GameObject canvas;
	public Slider healthBar;
	private int timer;


	void Awake () {

		healthBar.value = Prefs.playerHealth;
		timer = 0;
	}
    

    void accumulatehealth()
    {
		Prefs.playerHealth += 10;

		if (Prefs.playerHealth > 100) {
			
			Prefs.playerHealth = 100;

		}
		healthBar.value = Prefs.playerHealth;


    }

    void Update () {

		healthBar.value = Prefs.playerHealth;
		//this line is necessary to make sure any changes to the 
		//health made outside of this script are shown on the healthbar

		timer++;

		if (timer == 600) { // seconds
			timer = 0;
			accumulatehealth ();
		}

	}
}
