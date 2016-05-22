using UnityEngine;
using System.Collections;


// add this to clown/enemy
// add audio source with sword sound to enemy
// drag audio source to script
// drag A03/player to script

public class patrolAttack : MonoBehaviour {

	Animator animator;
	NavMeshAgent agent;
	int enemyhealth;
	InputScript inputScript;
	public AudioSource swordHitSFX;
	public Animator playerAnimator;


	// Use this for initialization
	void Start () {
		
		animator = GetComponentInChildren<Animator> ();
		agent = GetComponentInChildren<NavMeshAgent> ();
		enemyhealth = 100;
		inputScript = FindObjectOfType<InputScript> ();

	}

	void OnTriggerEnter(Collider col) {

		if (col.tag == "Player") {

			if (playerAnimator.GetBool ("hasSword") && inputScript.isAttacking) {
				if (Prefs.sfxEnabled) {
					swordHitSFX.Play ();
				}
				if (enemyhealth <= 100) {
					enemyhealth -= 25;
					if (enemyhealth == 0) {
						animator.SetTrigger ("dieClownDie");
						animator.SetBool ("isDead", true);
						agent.enabled = false;
					} else {
						animator.SetTrigger ("respondToAttack");
						gameObject.transform.LookAt (col.gameObject.transform);
						animator.SetTrigger ("clownAttack");
						animator.SetBool ("isWalking", true);
					}
				}
			} else {
				if (enemyhealth > 0) {
					Prefs.playerHealth -= 5;
				}

			}
		}
	}
		



	// Update is called once per frame
	void Update () {
	
	}
}
