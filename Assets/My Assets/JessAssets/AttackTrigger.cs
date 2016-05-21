using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	bool attackMode = false;
	int currEnemyId = 0;

	public GameObject[] enemyObjects;

	GameObject player;
	public GameObject camera;

	AudioSource evilLaugh;







	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {

			player = col.gameObject;

			attackMode = true;

			foreach (GameObject enemyObj in enemyObjects) {

				Animator enemyAnimator = enemyObj.GetComponentInChildren<Animator> ();
				NavMeshAgent enemyAgent = enemyObj.GetComponentInChildren<NavMeshAgent> ();

				enemyAnimator.SetBool ("isSitting", false);
				enemyAnimator.SetBool ("isKneeling", false);
				enemyAnimator.SetBool ("isWalking", false);

				if (currEnemyId == 1) {
					enemyAnimator.SetTrigger ("Laugh");
					if (Prefs.sfxEnabled) {
						evilLaugh = enemyObj.GetComponentInChildren<AudioSource> ();
						evilLaugh.Play ();
					}
									}
				enemyObj.transform.LookAt (player.transform);

				currEnemyId++;

			}
		}
	}




	void Start () {

	}
	
	void Update () {
			
		foreach (GameObject enemyObj in enemyObjects){
			if (player != null) {
			
				Animator enemyAnimator = enemyObj.GetComponentInChildren<Animator> ();
				NavMeshAgent enemyAgent = enemyObj.GetComponentInChildren<NavMeshAgent> ();

				if (enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {

					if (!enemyAnimator.GetBool("isDead")) {
						Vector3 newPos = new Vector3 ();
						newPos.x = player.transform.position.x + player.transform.forward.x;
						newPos.y = player.transform.position.y + player.transform.forward.y;
						newPos.z = player.transform.position.z;
						enemyAgent.destination = newPos;
						
						if (enemyAgent.transform.position != enemyAgent.destination) {
							enemyObj.transform.LookAt (player.transform);
							enemyAnimator.SetBool ("isWalking", true);
						
						} else {
							enemyObj.transform.LookAt (player.transform);
							enemyAnimator.SetBool ("isWalking", false);
						}
					}

				}
			}
		}
	}
}
