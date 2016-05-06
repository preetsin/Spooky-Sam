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

				// enemies all stand up to face player
				enemyAnimator.SetBool ("isSitting", false);
				enemyAnimator.SetBool ("isKneeling", false);
				enemyAnimator.SetBool ("isWalking", false);

				if (currEnemyId == 1) { // middle clown starts the fight
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
			
		Animator enemyAnimator = enemyObjects[1].GetComponentInChildren<Animator> ();
		NavMeshAgent enemyAgent = enemyObjects[1].GetComponentInChildren<NavMeshAgent> ();

		if (player != null) {

			if (enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {

//				enemyAgent.destination = player.transform.position + player.transform.forward;


				Vector3 newPos = new Vector3 ();
				newPos.x = player.transform.position.x + player.transform.forward.x;
				newPos.y = player.transform.position.y + player.transform.forward.y;
				newPos.z = player.transform.position.z;
				enemyAgent.destination = newPos;


				if (enemyAgent.transform.position != enemyAgent.destination) {
					
					// walk towards player, always watching
					enemyAnimator.SetBool ("isWalking", true);
					enemyObjects [1].transform.LookAt (player.transform);	

				} else {
					
					// stop walking when destination is reached
					enemyAnimator.SetBool ("isWalking", false);
				}
	
			}

		}


	}
}
