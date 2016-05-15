using UnityEngine;
using System.Collections;

public class Clown_huddle : MonoBehaviour {

	NavMeshAgent agent;
	public Animator animator;
	public bool kneel = false;
	public bool sit = false;
	private int enemyhealth;

	public AudioSource swordHitSFX;
//	public AudioSource swordHitForKillSFX;




	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator.SetBool ("isKneeling", kneel);
		animator.SetBool ("isSitting", sit);
		enemyhealth = 100;
	}

	void OnTriggerEnter(Collider col) {
		swordHitSFX.Play ();
		if (enemyhealth <= 100) {
			enemyhealth -= 25;
			if (enemyhealth == 0) {
				animator.SetTrigger ("dieClownDie");
				animator.SetBool ("isDead", true);
			} else {
				animator.SetTrigger ("respondToAttack");
			}
		}		
	}
	
	void Update () {}
}
