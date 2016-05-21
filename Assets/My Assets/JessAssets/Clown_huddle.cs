﻿using UnityEngine;
using System.Collections;

public class Clown_huddle : MonoBehaviour {

	NavMeshAgent agent;
	public GameObject gameObj;
	public Animator animator;
	public Animator playerAnimator;
	public bool kneel = false;
	public bool sit = false;
	private int enemyhealth;
	InputScript inputScript;

	public AudioSource swordHitSFX;




	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator.SetBool ("isKneeling", kneel);
		animator.SetBool ("isSitting", sit);
		enemyhealth = 100;
		inputScript = FindObjectOfType<InputScript> ();
	}

	void OnTriggerEnter(Collider col) {

		if (col.tag == "Player" && inputScript.isAttacking) {

			if (playerAnimator.GetBool ("hasSword")) {
				if (Prefs.sfxEnabled) {
					swordHitSFX.Play ();
				}
				if (enemyhealth <= 100) {
					enemyhealth -= 25;
					if (enemyhealth == 0) {
						animator.SetTrigger ("dieClownDie");
						animator.SetBool ("isDead", true);
						Prefs.clownDeathToll += 1;
					} else {
						animator.SetTrigger ("respondToAttack");
						gameObj.transform.LookAt (col.gameObject.transform);
						animator.SetTrigger ("clownAttack");
						animator.SetBool ("isWalking", true);
					}
				}
			} else {
				//alertview warning don't have sword
			}
		}
	}
	
	void Update () {}
}
