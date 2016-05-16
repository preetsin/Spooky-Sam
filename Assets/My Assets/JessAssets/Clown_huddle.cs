using UnityEngine;
using System.Collections;

public class Clown_huddle : MonoBehaviour {

	NavMeshAgent agent;
	public Animator animator;
	public Animator playerAnimator;
	public bool kneel = false;
	public bool sit = false;
	private int enemyhealth;

	public AudioSource swordHitSFX;




	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator.SetBool ("isKneeling", kneel);
		animator.SetBool ("isSitting", sit);
		enemyhealth = 100;
	}

	void OnTriggerEnter(Collider col) {

		if (col.tag == "Player") {

			//anim.trigger attack

//			if (playerAnimator.GetBool ("hasSword")) {
				swordHitSFX.Play ();
				if (enemyhealth <= 100) {
					enemyhealth -= 25;
					if (enemyhealth == 0) {
						animator.SetTrigger ("dieClownDie");
						animator.SetBool ("isDead", true);
					} else {
						animator.SetTrigger ("respondToAttack");
						animator.transform.LookAt (col.gameObject.transform);
						animator.SetTrigger ("clownAttack");
						animator.SetBool ("isWalking", true);
					}
				}
//			} else {
//				//alertview warning don't have sword
//			}
		}
	}
	
	void Update () {}
}
