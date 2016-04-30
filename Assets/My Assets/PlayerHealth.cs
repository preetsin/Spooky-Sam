using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int health;
    public GameObject canvas;
	public Slider healthBar;
	private int timer;


	void Awake () {
        health = 50;

		healthBar.value = health;
		timer = 0;
	}
    

    void accumulatehealth()
    {
		health += 10;

		if (health > 100) {
			
			health = 100;

		}
		healthBar.value = health;

    }

    // Update is called once per frame
    void Update () {

		timer++;

		if (timer == 600) { // seconds
			timer = 0;
			accumulatehealth ();
		}

	}
}
