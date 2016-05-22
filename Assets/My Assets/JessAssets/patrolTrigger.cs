using UnityEngine;
using System.Collections;

public class patrolTrigger : MonoBehaviour {

	public GameObject[] enemies;

	private bool triggered;
	private GameObject player;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {

			triggered = true;
			player = col.gameObject;

		}
	}



	// Use this for initialization
	void Start () {
		triggered = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (triggered) {
			foreach (GameObject enemyObj in enemies) {

				Animator enemyAnimator = enemyObj.GetComponentInChildren<Animator> ();
				NavMeshAgent enemyAgent = enemyObj.GetComponentInChildren<NavMeshAgent> ();

				if (!enemyAnimator.GetBool ("isDead")) {
					
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
