using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	bool attackMode = false;
	int currentEnemyId = 0;
	public GameObject[] enemyObjects;

	GameObject player;







	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {

			player = col.gameObject;

			attackMode = true;

			foreach (GameObject enemyObj in enemyObjects) {

				Animator enemyAnimator = enemyObj.GetComponentInChildren<Animator> ();

				// enemies all stand up to face player
				enemyAnimator.SetBool ("isSitting", false);
				enemyAnimator.SetBool ("isKneeling", false);
				enemyAnimator.SetBool ("isWalking", false);

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
