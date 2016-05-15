using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public GameObject canvas;
	public Slider healthBar;
	private int timer;
    public bool healthIncremented;

	void Awake () {

		healthBar.value = Prefs.playerHealth;
		timer = 0;
	}
    

    void accumulatehealth()
    {


		Prefs.playerHealth += 10;
        canvas.GetComponent<RawImage>().enabled = true;
        if (Prefs.playerHealth > 100) {
			
			Prefs.playerHealth = 100;

		}
		healthBar.value = Prefs.playerHealth;
        healthIncremented = true;

    }

    void Update () {

		healthBar.value = Prefs.playerHealth;

		if (Prefs.playerHealth <= 10) {
            canvas.GetComponent<RawImage>().enabled = true;
		} else {
            StartCoroutine(disableImage());
        }

		timer++;

		if (timer == 600) { // seconds
			timer = 0;
			accumulatehealth ();
		}



	}
    IEnumerator disableImage()
    {
        while (Prefs.lastHealth > Prefs.playerHealth)
        {
            canvas.GetComponent<RawImage>().enabled = true;
            yield return new WaitForSeconds(0.15f);
            canvas.GetComponent<RawImage>().enabled = false;
            Prefs.lastHealth = Prefs.playerHealth;
        }

    }
}
