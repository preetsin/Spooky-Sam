using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public GameObject canvas;
	public Slider healthBar;
	private int timer;
    public static int lastHealth;


    void Awake () {
        lastHealth = Prefs.playerHealth;
		healthBar.value = Prefs.playerHealth;
		timer = 0;
        StartCoroutine(healthUpdate());
	}
    

    void accumulatehealth()
    {

		Prefs.playerHealth += 10;
        canvas.GetComponent<RawImage>().enabled = false;
        if (Prefs.playerHealth > 100) {
			Prefs.playerHealth = 100;
		}
		healthBar.value = Prefs.playerHealth;
    }

    void Update () {

		healthBar.value = Prefs.playerHealth;
       
		if (Prefs.playerHealth <= 10) {
            canvas.GetComponent<RawImage>().enabled = true;
		} else {
            StartCoroutine(disableImage());
            lastHealth = Prefs.playerHealth;
        }
       
      // timer++;

		//if (timer == 600) { // seconds
		//	timer = 0;
		//	accumulatehealth ();
		//}
	}


    IEnumerator healthUpdate() {
        while (true) {
            yield return new WaitForSeconds(8);
            accumulatehealth();
        }
    }


    IEnumerator disableImage()
    {
        while (lastHealth > Prefs.playerHealth)
        {
            
            canvas.GetComponent<RawImage>().enabled = true;
            yield return new WaitForSeconds(0.15f);
            canvas.GetComponent<RawImage>().enabled = false;
            
        }

    }
}
