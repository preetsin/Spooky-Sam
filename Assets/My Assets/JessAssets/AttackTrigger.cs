using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	bool attackMode = false;
	int currentEnemyId = 0;
	public GameObject[] enemyObjects;

	GameObject player;

	AudioSource evilLaugh;







	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {

			player = col.gameObject;

			attackMode = true;
			int currEnemyId = 0;
			foreach (GameObject enemyObj in enemyObjects) {

				Animator enemyAnimator = enemyObj.GetComponentInChildren<Animator> ();

				// enemies all stand up to face player
				enemyAnimator.SetBool ("isSitting", false);
				enemyAnimator.SetBool ("isKneeling", false);
				enemyAnimator.SetBool ("isWalking", false);

				if (currEnemyId == 1) {
					enemyAnimator.SetTrigger ("Laugh");
					evilLaugh = enemyObj.GetComponentInChildren<AudioSource> ();
					evilLaugh.Play ();
				}

				currEnemyId++;

				enemyObj.transform.LookAt (player.transform);

			}
		}
	}


	void Start () {

	
	}
	
	void Update () {

		if (attackMode) {

		}
	
	}
}
