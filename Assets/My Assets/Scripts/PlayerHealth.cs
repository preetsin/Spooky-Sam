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

		if (Prefs.playerHealth <= 10) {
			//make screen low-alpha red here!!!!
			//change colour of the health bar to red (if green)
		} else {
			//remove red alpha overlay
			//return health bar to green (if red)		
		}

		timer++;

		if (timer == 600) { // seconds
			timer = 0;
			accumulatehealth ();
		}



	}
}
